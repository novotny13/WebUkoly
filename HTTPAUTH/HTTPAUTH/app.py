import qrcode
import uuid
import sqlite3
from flask import Flask, request, redirect, url_for, render_template
from datetime import datetime, timedelta

app = Flask(__name__)


temp_tokens = {}


def get_db_connection():
    conn = sqlite3.connect('users.db')
    conn.row_factory = sqlite3.Row
    return conn


@app.route('/register', methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        username = request.form['username']

        # Zkontrolujte, zda uživatel neexistuje
        conn = get_db_connection()
        user = conn.execute('SELECT * FROM users WHERE username = ?', (username,)).fetchone()
        conn.close()

        if user:
            return 'Uzivatel jiz existuje. Zvolte jine jmeno.'

       
        token = str(uuid.uuid4())
        expiry = datetime.now() + timedelta(minutes=5)
        temp_tokens[token] = {'username': username, 'expiry': expiry}

       
        qr_url = f'http://{request.host}/set_password/{token}'
        qr_img = qrcode.make(qr_url)
        qr_img.save(f'static/qr_codes/{username}_qr.png')

        return f'QR kód vygenerován. <a href="/static/qr_codes/{username}_qr.png">Stáhněte QR kód</a> a naskenujte ho pro nastavení hesla.'

    return '''
        <form method="POST">
            <label for="username">Uživatelské jméno:</label>
            <input type="text" id="username" name="username" required>
            <button type="submit">Registrovat</button>
        </form>
    '''


@app.route('/set_password/<token>', methods=['GET', 'POST'])
def set_password(token):
    if token not in temp_tokens:
        return 'Neplatný nebo expirovaný token.', 400

    token_data = temp_tokens[token]


    if datetime.now() > token_data['expiry']:
        return 'Token vypršel.', 400

    if request.method == 'POST':
        password = request.form['password']
        username = token_data['username']

       
        conn = get_db_connection()
        conn.execute('INSERT INTO users (username, password) VALUES (?, ?)', (username, password))
        conn.commit()
        conn.close()

       
        del temp_tokens[token]

        return f'Heslo nastaveno. <a href="/login">Přihlaste se zde</a>.'

    return '''
        <form method="POST">
            <label for="password">Zadejte heslo:</label>
            <input type="password" id="password" name="password" required>
            <button type="submit">Odeslat</button>
        </form>
    '''


@app.route('/login', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        username = request.form['username']
        password = request.form['password']

        
        conn = get_db_connection()
        user = conn.execute('SELECT * FROM users WHERE username = ? AND password = ?', (username, password)).fetchone()
        conn.close()

        if user:
            return redirect(url_for('welcome', username=username))
        else:
            return 'Nesprávné uživatelské jméno nebo heslo.', 400

    return '''
        <form method="POST">
            <label for="username">Uživatelské jméno:</label>
            <input type="text" id="username" name="username" required>
            <label for="password">Heslo:</label>
            <input type="password" id="password" name="password" required>
            <button type="submit">Přihlásit se</button>
        </form>
    '''


@app.route('/welcome/<username>')
def welcome(username):
    return f'Vítejte, {username}!'

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8080, debug=True)


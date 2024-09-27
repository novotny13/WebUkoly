import sqlite3

# Připojení k databázi
conn = sqlite3.connect('users.db')
c = conn.cursor()

# Vytvoření tabulky uživatelů
c.execute('''
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT UNIQUE NOT NULL,
    password TEXT NOT NULL
)
''')

conn.commit()
conn.close()

print("Databáze byla inicializována.")


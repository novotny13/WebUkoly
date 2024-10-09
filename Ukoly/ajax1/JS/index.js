const express = require('express');
const mysql = require('mysql');
const { host, user, pass, db } = require('./config');
const Service = require('./service');

const app = express();
app.use(express.static('public'));
app.use(express.urlencoded({ extended: true }));

const connection = mysql.createConnection({
    host: host,
    user: user,
    password: pass,
    database: db
});

connection.connect((err) => {
    if (err) {
        console.error('Connection failed: ' + err.stack);
        return;
    }
    console.log('Connected successfully as id ' + connection.threadId);
});

app.get('/', (req, res) => {
    const ser = new Service(connection);
    res.send(generateForm(ser));
});

function generateForm(service) {
    let html = '<!DOCTYPE HTML><html><head><meta charset="utf-8">';
    html += '<meta name="viewport" content="width=device-width, initial-scale=1.0">';
    html += '<title></title><style>#form {width:100rem} #form label{width:10rem;display:inline-block}';
    html += '#form input{width:80rem;} #form label, #form input {height:2rem;margin: 1rem 0}</style></head>';
    html += '<body><form action="requests?cmd=list" method="post"><div id="form">';
    html += generateOptions(service.getPeopleList());
    html += generateCheckBoxes(service.getTypesList());
    html += '<button type="button">Uložit</button></div><input type="submit" value="odeslat"></form>';
    html += '<script src="https://code.jquery.com/jquery-3.6.1.min.js" ';
    html += 'integrity="sha256-o88AwQnZB+VDvE9tvIXrMQaPlFFSUTR+nldQm1LuPXQ=" crossorigin="anonymous"></script>';
    html += '<script src="js.js"></script></body></html>';
    return html;
}

function generateCheckBoxes(arr) {
    let html = "";
    arr.forEach(item => {
        html += `<label for='${item.ID}'>${item.typ}</label>`;
        html += `<input type='number' name='type[]' value='0'><br>`;
    });
    return html;
}

function generateOptions(arr) {
    let html = "";
    arr.forEach(item => {
        html += `<label for='${item.ID}'>${item.name}</label>`;
        html += `<input type='radio' name='user' value='${item.ID}'><br>`;
    });
    return html;
}

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});

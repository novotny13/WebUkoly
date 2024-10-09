const express = require('express');
const mysql = require('mysql');
const cors = require('cors');
const basicAuth = require('express-basic-auth');
const bodyParser = require('body-parser');
const { host, user, pass, db } = require('./config');
const Requests = require('./requests');

const app = express();

app.use(cors({
    origin: (origin, callback) => {
        callback(null, true);
    },
    credentials: true,
    maxAge: 86400
}));

app.use(basicAuth({
    users: { 'coffe': 'kafe' },
    challenge: true,
    unauthorizedResponse: { msg: 'Text to send if user hits Cancel button' }
}));

app.use(bodyParser.json());

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
    const r = new Requests(connection);
    res.json(r);
});

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});

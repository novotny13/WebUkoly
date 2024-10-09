const mysql = require('mysql');
const { host, user, pass, db } = require('./config');

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

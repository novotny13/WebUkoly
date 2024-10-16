const mysql = require('mysql2');


const config = {
    host: 'localhost',
    user: '',
    password: '',
    database: 'coffe_lmsoft_cz'
};


const connection = mysql.createConnection(config);


connection.connect((err) => {
    if (err) {
        console.error('Database connection failed:', err.message);
        process.exit(1); // Exit process on failure
    } else {
        console.log('Connected successfully to the database.');
    }
});


module.exports = connection;

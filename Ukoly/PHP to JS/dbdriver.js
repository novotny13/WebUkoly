const mysql = require('mysql2');

class DbDriver {
    constructor(connection) {
        if (!connection) {
            throw new Error('Connection cannot be null');
        }
        this.cn = connection;
    }


    query(sql) {
        return new Promise((resolve, reject) => {
            this.cn.query(sql, (err, results) => {
                if (err) {
                    return reject(err);
                }
                resolve(results[0]); 
            });
        });
    }

   
    select(table, columns) {
        const columnList = Array.isArray(columns) ? columns.join(', ') : columns;
        const sql = `SELECT ${columnList} FROM ${table}`;

        return new Promise((resolve, reject) => {
            this.cn.query(sql, (err, results) => {
                if (err) {
                    return reject(err);
                }
                resolve(results); // Return all results
            });
        });
    }

    
    insertRow(valuesArray) {
        if (!Array.isArray(valuesArray)) {
            return Promise.reject(new Error('Input should be an array'));
        }

        const values = valuesArray.map(value => `'${value}'`).join(', ');
        const sql = `INSERT INTO drinks VALUES (NULL, ${values})`; 

        return new Promise((resolve, reject) => {
            this.cn.query(sql, (err, results) => {
                if (err) {
                    return reject(err);
                }
                resolve(results.affectedRows); 
            });
        });
    }

    selectQuery(sql) {
        return new Promise((resolve, reject) => {
            this.cn.query(sql, (err, results) => {
                if (err) {
                    return reject(err);
                }
                resolve(results);
            });
        });
    }
}

module.exports = DbDriver;

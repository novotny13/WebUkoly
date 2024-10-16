const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');

class Service {
    constructor(conn) {
        this.conn = conn; // Connection setup (unused in the current logic)
    }

    getPeopleList() {
        return [
            { ID: 1, name: 'Alice' },
            { ID: 2, name: 'Bob' }
        ];
    }

    getTypesList() {
        return [
            { ID: 1, typ: 'Coffee' },
            { ID: 2, typ: 'Tea' }
        ];
    }
}

const app = express();
const PORT = process.env.PORT || 3000;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, 'public')));


const generateInputs = (arr, labelKey, inputName, type = 'radio') => {
    return arr.map(item => `
        <label for="${item.ID}">${item[labelKey]}</label>
        <input type="${type}" name="${inputName}" value="${item.ID}" ${type === 'number' ? 'value="0"' : ''}><br>
    `).join('');
};


app.get('/', (req, res) => {
    const service = new Service();

    const peopleList = service.getPeopleList();
    const typesList = service.getTypesList();

    res.send(`
    <!DOCTYPE HTML>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Drink Submission</title>
        <style>
          #form { width: 100rem; }
          #form label { width: 10rem; display: inline-block; }
          #form input { width: 80rem; }
          #form label, #form input { height: 2rem; margin: 1rem 0; }
        </style>
    </head>
    <body>
        <form action="/api/requests" method="post">
            <div id="form">
                ${generateInputs(peopleList, 'name', 'user')}
                ${generateInputs(typesList, 'typ', 'type[]', 'number')}
                <button type="submit">Uložit</button>
            </div>
            <input type="submit" value="Odeslat">
        </form>
    </body>
    </html>
    `);
});

// Handle form submission
app.post('/api/requests', (req, res) => {
    console.log(req.body); // Log the submitted data
    res.json({ msg: 'Form submitted successfully!', data: req.body });
});

// Start the server
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

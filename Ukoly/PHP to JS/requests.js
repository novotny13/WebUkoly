const express = require('express');
const bodyParser = require('body-parser');

class RequestHandler {
    constructor(service) {
        this.service = service;
        this.router = express.Router();

    
        this.setupMiddleware();

   
        this.setupRoutes();
    }

    setupMiddleware() {
        this.router.use(bodyParser.json());
        this.router.use(bodyParser.urlencoded({ extended: true }));
    }

    setupRoutes() {
        this.router.get('/cmd/:cmd?', (req, res) => this.controller(req.params.cmd, req.query, res));
        this.router.post('/cmd/saveDrinks', (req, res) => this.controller('saveDrinks', req.body, res));
        this.router.get('/cmd/listCmd', (req, res) => this.controller('listCmd', {}, res));
    }

    controller(cmd, data, res) {
        const commandMap = {
            'getPeopleList': () => this.service.getPeopleList(),
            'getTypesList': () => this.service.getTypesList(),
            'saveDrinks': () => this.service.saveDrinks(data),
            'listCmd': () => ['getPeopleList', 'getTypesList', 'saveDrinks', 'getSummaryOfDrinks'],
            'getSummaryOfDrinks': () => this.service.getSummaryOfDrinks(data)
        };

        const result = commandMap[cmd] ? commandMap[cmd]() : "err";
        this.output(result, res);
    }

    output(data, res) {
        res.json(Array.isArray(data) ? data : { msg: data });
    }
}


const app = express();
const service = new Service(); 
const requestHandler = new RequestHandler(service);

app.use('/api', requestHandler.router);

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

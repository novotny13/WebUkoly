const express = require('express');
const bodyParser = require('body-parser');

const app = express();
const PORT = process.env.PORT || 3000;


const corsMiddleware = (req, res, next) => {
    if (req.headers.origin) {
        res.setHeader('Access-Control-Allow-Origin', req.headers.origin);
        res.setHeader('Access-Control-Allow-Credentials', 'true');
        res.setHeader('Access-Control-Max-Age', '86400'); // Cache for 1 day
    }

    if (req.method === 'OPTIONS') {
        if (req.headers['access-control-request-method']) {
            res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS');
        }
        if (req.headers['access-control-request-headers']) {
            res.setHeader('Access-Control-Allow-Headers', req.headers['access-control-request-headers']);
        }
        return res.status(204).end(); // No content for OPTIONS preflight
    }

    next();
};


const basicAuthMiddleware = (req, res, next) => {
    const authHeader = req.headers['authorization'];

    if (!authHeader) {
        res.setHeader('WWW-Authenticate', 'Basic realm="Coffee"');
        return res.status(401).json({ msg: 'Unauthorized' });
    }

    const [user, pass] = Buffer.from(authHeader.split(' ')[1], 'base64').toString().split(':');

    if (user === 'coffe' && pass === 'kafe') {
        return next();
    }

    res.setHeader('WWW-Authenticate', 'Basic realm="Coffee"');
    return res.status(401).json({ msg: 'Unauthorized' });
};


app.use(corsMiddleware);
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(basicAuthMiddleware);

// Database connection (replace with actual DB connection)
const db = require('./db'); // Replace with your actual DB module
const Requests = require('./requests'); // Replace with your actual requests module


app.get('/api', (req, res) => {
    const requests = new Requests(db);
    // Request handling logic here
    res.json({ msg: 'API is working' });
});


app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

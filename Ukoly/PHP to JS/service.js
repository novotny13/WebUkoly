const http = require('http');

const HOSTNAME = '127.0.0.1';
const PORT = process.env.PORT || 3000;


const handleRequest = (req, res) => {
  res.statusCode = 200;
  res.setHeader('Content-Type', 'application/json');
  const responseMessage = JSON.stringify({ message: 'Hello, World!' });
  res.end(responseMessage);
};


const server = http.createServer(handleRequest);

server.listen(PORT, HOSTNAME, () => {
  console.log(`Server running at http://${HOSTNAME}:${PORT}/`);
});

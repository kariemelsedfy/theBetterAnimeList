const express = require('express');
const cors = require('cors');
const session = require('express-session');

const app = express();
const login = require('./routes/login');
const getToken = require('./routes/getToken');
const buildSuggestedAnimeList = require('./routes/buildSuggestedAnimeList');
const getSuggestedAnimes = require('./routes/getSuggestedAnimes');
const deleteUserAnimeRow = require('./routes/deleteUserAnimeRow');
const patchAnimeList = require('./routes/patchAnimeList');
const databaseContainsUser = require('./routes/databaseContainsUser');

const bodyParser = require('body-parser');
app.use(bodyParser.json())
app.use(express.json())
app.use(cors());



app.get('/', (req, res) => {
  res.send('Hello, World!');
});

app.use('/api/login', login);
app.use('/api/getToken', getToken);
app.use('/api/buildSuggestedAnimeList', buildSuggestedAnimeList);
app.use('/api/getSuggestedAnimes', getSuggestedAnimes);
app.use('/api/deleteUserAnimeRow', deleteUserAnimeRow);
app.use('/api/patchAnimeList', patchAnimeList);
app.use('/api/databaseContainsUser', databaseContainsUser);




app.listen(3000, () => {
  console.log('Server is running on http://localhost:3000');
});
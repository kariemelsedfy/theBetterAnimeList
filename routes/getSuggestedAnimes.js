// Returns the suggested anime list stored in the database.

const express = require('express');
const router = express.Router();


const getUserID = require('./builtSuggestedAnimeList/getUserID');
const getSuggestedAnimeList = require('../database/getSuggestedAnimeList');


router.post('/', async (req, res) => {
    try {
        const token = req.body.MAL_ACCESS_TOKEN;
        const userID = await getUserID(token);

        const suggestedAnimeList = await getSuggestedAnimeList(userID);
        
        if (suggestedAnimeList.length >= 20) {
            res.send(suggestedAnimeList.slice(0, 20));
        } else {
            res.send(suggestedAnimeList);
        }
    } catch (err) {
        console.error('Error /api/getSuggestedAnimes:', err.response?.data || err.message);
        res.status(500).json({ error: 'Failed to fetch profile suggestions' });
    }

});


module.exports = router;
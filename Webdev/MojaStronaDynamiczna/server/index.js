const express = require('express')
const app = express()
const cors = require('cors')

app.use(express.json())
app.use(cors());

const db = require ('./models')

const memes_router = require ('./routes/memes')
app.use("/memes", memes_router);
const users_router = require ('./routes/users')
app.use("/users", users_router);

// jeśli nie istnieją utwórz wymagane tabele w bazie danych
db.sequelize.sync().then(() => {
	// uruchom serwer na porcie 3001
	app.listen(3001, () => {
		console.log("Uruchomiono serwer na porcie 3001");
	})
})
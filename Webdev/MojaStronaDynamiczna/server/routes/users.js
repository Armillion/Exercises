const express = require ('express')
const router = express.Router ()
const { users } = require ('../models')
const bcrypt = require ('bcrypt')
const {sign} = require('jsonwebtoken')

router.get('/hash/:password', async (req, res) => {
	const password = req.params.password
	bcrypt.hash (password, 10).then ((hash) => {
		res.json ({
			password: password,
			hash: hash
		})
	})
})

router.post('/login', async (req, res) => {
	const { username, password } = req.body
	
	if (!username || !password) {
		return res.json ({
			error: 'Missing data'
		})
	}
	
	const user = await users.findOne({
		where: {
			username: username
		}
	})
	
	if (!user) {
		return res.json ({
			error: 'Username not found'
		})
	}
	
	bcrypt.compare (password, user.password_hash).then((match) => {
		if (!match) {
			return res.json({
				error: 'Incorrect password'
			})
		}
		
		const access_token = sign({  
			user_id: user.id,
			username: user.username
		}, "website_password")
		
		return res.json({
			message: 'Succesfully logged in',
			jwt: access_token
		})
	})
})

module.exports = router
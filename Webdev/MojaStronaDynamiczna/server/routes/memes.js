const express = require ('express')
const router = express.Router ()
const { memes, upvotes } = require ('../models')
const { validateToken } = require('../middlewares/AuthMiddleware.js')
const {verify} = require('jsonwebtoken')

router.get('/', async (req, res) => {
	const access_token = req.header('access_token')
	
	if (access_token != "null") {
		
		try {
			const validToken = verify(access_token, "website_password")
			
			if (validToken) {
				
				const memesArray = await memes.findAll ({
					include: [{
						model: upvotes,
						as: "upvotes"
					}]
				})
				
				for (let i = 0; i < memesArray.length; i++) {
					memesArray[i].dataValues.liked = false
					for (let j = 0; j < memesArray[i].dataValues.upvotes.length; j++) {
						if (memesArray[i].dataValues.upvotes[j].user_id == validToken.user_id)
							memesArray[i].dataValues.liked = true
					}
					memesArray[i].dataValues.upvotes = memesArray[i].dataValues.upvotes.length
				}
				return res.json(memesArray)
				
			}
		} catch (err) {
			return res.json({
				error: err.message
			})
		}
		
	} else {
		
		const memesArray = await memes.findAll ({
			include: [{
				model: upvotes,
				as: "upvotes"
			}]
		})
		for (let i = 0; i < memesArray.length; i++) {
			memesArray[i].dataValues.liked = false
			memesArray[i].dataValues.upvotes = memesArray[i].dataValues.upvotes.length
		}
		return res.json(memesArray)
	}
})

router.get('/my-memes/', validateToken, async (req, res) => {
	const memesArray = await memes.findAll ({
		where: {
			author_id: req.jwt.user_id
		},
		include: [{
			model: upvotes,
			as: "upvotes"
		}]
	})
	for (let i = 0; i < memesArray.length; i++) {
		memesArray[i].dataValues.liked = false
		for (let j = 0; j < memesArray[i].dataValues.upvotes.length; j++) {
			if (memesArray[i].dataValues.upvotes[j].user_id == req.jwt.user_id)
				memesArray[i].dataValues.liked = true
		}
		memesArray[i].dataValues.upvotes = memesArray[i].dataValues.upvotes.length
	}
	res.json(memesArray)
})

router.post('/upload', async (req, res) => {
	const memeData = req.body
	console.log(memeData)
	await memes.create(memeData)
	res.json(memeData)
})

router.get('/upvote/:id', async (req, res) => {
	res.json()
})

module.exports = router
const express = require ('express')
const router = express.Router ()
const { upvotes } = require ('../models')
const { validateToken } = require('../middlewares/AuthMiddleware')

router.get('/meme/:meme_id/', validateToken, async (req, res) => {
	const meme_id = req.params.meme_id
	const user_id = req.jwt.user_id
	
	console.log (`meme ${meme_id} prepare by user ${user_id}`)
	
	const meme_upvote = await upvotes.findOne({
		where: {
			meme_id: meme_id,
			user_id: user_id
		}
	})
	
	if (meme_upvote) {
		await upvotes.destroy({
			where: {
				meme_id: meme_id,
				user_id: user_id
			}
		})
		res.json({
			message: "downvoted"
		})
	} else {
		await upvotes.create({
			meme_id: meme_id,
			user_id: user_id
		})
		res.json({
			message: "upvoted"
		})
	}
	
})

module.exports = router
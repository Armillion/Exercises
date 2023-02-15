const express = require ('express')
const router = express.Router ()
const { upvotes } = require ('../models')

router.get('/meme/:meme_id/user/:user_id', async (req, res) => {
	const meme_id = req.params.meme_id
	const user_id = req.params.user_id
	
	const meme_upvote = await memes.findOne({
		where: {
			meme_id: meme_id,
			user_id: user_id
		}
	})
	
	if (meme_upvote) {
		await memes.destroy({
			where: {
				meme_id: meme_id,
				user_id: user_id
			}
		})
	} else {
		await memes.create({
			meme_id: meme_id,
			user_id: user_id
		})
	}
	res.json({
		message: 200
	})
})

module.exports = router
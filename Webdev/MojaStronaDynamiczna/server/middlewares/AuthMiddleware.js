const {verify} = require('jsonwebtoken')

const validateToken = (req, res, next) => {
	const access_token = req.header('access_token')
	
	if (!access_token) {
		return res.json({
			error: "Missing token!"
		})
	}
	
	try {
		const validToken = verify(access_token, "website_password")
		
		req.jwt = validToken
		
		if (validToken) {
			return next()
		}
	} catch (err) {
		return res.json({
			error: err
		})
	}
	
}

module.exports = {validateToken}
module.exports = (sequelize, DataTypes) => {
	
	const upvotes = sequelize.define("upvotes", {
		
	},
	{
		tableName: 'upvotes',
		timestamps: false
	})
	
	return upvotes
}
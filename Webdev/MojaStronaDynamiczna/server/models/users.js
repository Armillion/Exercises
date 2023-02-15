module.exports = (sequelize, DataTypes) => {
	
	const users = sequelize.define("users", {
		username: {
			type: DataTypes.STRING,
			allowNull: false,
		},
		email: {
			type: DataTypes.STRING,
			allowNull: false,
		},
		password_hash: {
			type: DataTypes.STRING(60),
			allowNull: false,
		}
	},
	{
		tableName: 'users',
		timestamps: false
	})
	
	users.associate = (models) => {
		users.hasMany(models.memes, {
			foreignKey: 'author_id'
		})
		users.hasMany(models.upvotes, {
			foreignKey: 'user_id'
		})
	}
	
	return users
}
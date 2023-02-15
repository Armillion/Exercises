module.exports = (sequelize, DataTypes) => {
	
	const memes = sequelize.define("memes", {
		title: {
			type: DataTypes.STRING,
			allowNull: false,
		},
		image_base64: {
			type: DataTypes.STRING(1000000),
			allowNull: false,
		}
	},
	{
		tableName: 'memes',
		timestamps: false
	})
	
	memes.associate = (models) => {
		memes.hasMany(models.upvotes, {
			foreignKey: 'meme_id',
			as: 'upvotes'
		})
	}
	
	return memes
}
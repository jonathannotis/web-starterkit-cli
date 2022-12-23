const Users = require("../models/User");

exports.getAllUsers = async (req, res, next) => {
	try {
		const [users, _] = await Users.findAll();

		res.status(200).json(users);
	} catch (error) {
		next(error);
	}
};

exports.createNewUser = async (req, res, next) => {
	try {
		let { email, first_name, last_name } = req.body;
		let user = new Users(email, first_name, last_name);

		await user.save();

		res.status(201).json({ message: "User created" });
	} catch (error) {
		next(error);
	}
};

exports.getUserById = async (req, res, next) => {
	try {
		let userID = req.params.id;

		let [user, _] = await Users.findById(userID);

		res.status(200).json(user[0]);
	} catch (error) {
		next(error);
	}
};

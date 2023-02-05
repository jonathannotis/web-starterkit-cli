const Users = require("../models/User");

exports.getAllUsers = async (req, res) => {
	try {
		const users = await Users.findAll();

		res.status(200).json(users);
	} catch (error) {
		res.status(500).json({ message: error.message });
	}
};

exports.createNewUser = async (req, res) => {
	try {
		let { email, first_name, last_name } = req.body;
		let user = new Users(email, first_name, last_name);

		await user.save();

		res.status(200).json({ message: "User created" });
	} catch (error) {
		res.status(500).json({ message: error.message });
	}
};

exports.getUserById = async (req, res) => {
	try {
		let userID = req.params.id;

		let user = await Users.findById(userID);

		res.status(200).json(user[0]);
	} catch (error) {
		res.status(500).json({ message: error.message });
	}
};

exports.deleteUser = async (req, res) => {
	try {
		let userID = req.params.id;

		let user = await Users.deleteById(userID);

		res.status(200).json(user[0]);
	} catch {
		res.status(500).json({ message: error.message });
	}
};

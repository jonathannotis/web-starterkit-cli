const Users = require("../models/User");

exports.getAllUsers = async (req, res) => {
	try {
		const data = await Users.find();
		res.json(data);
	} catch (error) {
		res.status(500).json({ message: error.message });
	}
};

exports.createNewUser = async (req, res) => {
	const data = new Users({
		email: req.body.email,
		first_name: req.body.first_name,
		last_name: req.body.last_name,
	});

	try {
		const dataToSave = await data.save();
		res.status(200).json(dataToSave);
	} catch (error) {
		res.status(400).json({ message: error.message });
	}
};

exports.getUserById = async (req, res) => {
	try {
		const data = await Users.findById(req.params.id);
		res.json(data);
	} catch (error) {
		res.status(500).json({ message: error.message });
	}
};

exports.deleteUser = async (req, res) => {
	try {
		const data = await Model.findByIdAndDelete(req.params.id);
		res.send(`Document with ${data.name} has been deleted..`);
	} catch (error) {
		res.status(400).json({ message: error.message });
	}
};

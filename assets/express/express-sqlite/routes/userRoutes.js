const express = require("express");
const userControllers = require("../controllers/userControllers");
const router = express.Router();

router.post("/post", (req, res) => {
	userControllers.createNewUser(req, res);
});

//Get all Method
router.get("/get", (req, res) => {
	userControllers.getAllUsers(req, res);
});

//Get by ID Method
router.get("/get/:id", (req, res) => {
	userControllers.getUserById(req, res);
});

//Delete by ID Method
router.delete("/delete/:id", (req, res) => {
	userControllers.deleteUser(req, res);
});

module.exports = router;

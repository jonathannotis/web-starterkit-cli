require("dotenv").config(); // ALLOWS ENVIRONMENT VARIABLES TO BE SET ON PROCESS.ENV SHOULD BE AT TOP

// CREATE .env FILE WITH THE MONGODB CONNECTION STRING:
// DB_URL

const express = require("express");
const mongoose = require("mongoose");

const app = express();

mongoose.connect(process.env.DATABASE_URL);
const database = mongoose.connection;

database.on("error", (error) => {
	console.log(error);
});

database.once("connected", () => {
	console.log("Database Connected");
});

app.use(express.json());

// Redirect requests to endpoint starting with /posts to postRoutes.js
app.use("/users", require("./routes/userRoutes"));

app.use((err, req, res, next) => {
	console.log(err.stack);
	console.log(err.name);
	console.log(err.code);

	res.status(500).json({
		message: "Something went really wrong",
	});
});

// Listen on pc port
const PORT = 3000;
app.listen(PORT, () => console.log(`Server running on PORT ${PORT}`));

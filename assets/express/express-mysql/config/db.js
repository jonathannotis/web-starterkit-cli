require("dotenv").config();
const mysql = require("mysql2");

// CREATE THE FOLLOWING VARIABLES BASED ON YOUR MYSQL DB CONFIGURATION:
// DB_HOST
// DB_USER
// DB_NAME
// DB_PASSWORD

const pool = mysql.createConnection({
	host: process.env.DB_HOST,
	user: process.env.DB_USER,
	database: process.env.DB_NAME,
	password: process.env.DB_PASSWORD,
});

module.exports = pool.promise();

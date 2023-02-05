const sqlite3 = require("sqlite3").verbose();
const filepath = "./sqlite.db";

let db = new sqlite3.Database(":memory:", (err) => {
	if (err) {
		console.log("Error Occurred - " + err.message);
	} else {
		console.log("DataBase Connected");
	}
});

module.exports = db;

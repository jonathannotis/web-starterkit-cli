const db = require("../config/db");

class User {
	constructor(email, first_name, last_name) {
		this.email = email;
		this.first_name = first_name;
		this.last_name = last_name;
		createUserTable();
	}

	save() {
		let sql = `
    INSERT INTO user(
      email,
      first_name,
      last_name
    )
    VALUES('${this.email}', '${this.first_name}', '${this.last_name}')
    `;

		return db.run(sql);
	}

	static async findAll() {
		await createUserTable();
		let sql = "SELECT * FROM user;";

		return db.each(sql);
	}

	static async findById(id) {
		await createUserTable();
		let sql = `SELECT * FROM user WHERE user_id = ${id};`;

		return db.each(sql);
	}

	static async deleteById(id) {
		await createUserTable();
		let sql = `DELETE * FROM user WHERE user_id = ${id};`;

		return db.run(sql);
	}
}

function createUserTable() {
	db.exec(
		`CREATE TABLE IF NOT EXISTS user(user_id INTEGER PRIMARY KEY AUTOINCREMENT, email VARCHAR(70) NOT NULL, first_name VARCHAR(70) NOT NULL, last_name VARCHAR(70) NOT NULL);`
	);
}

module.exports = User;

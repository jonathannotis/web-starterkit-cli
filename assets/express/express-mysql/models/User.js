const db = require("../config/db");

class User {
	constructor(email, password, first_name, last_name, license_plate) {
		this.email = email;
		this.first_name = first_name;
		this.last_name = last_name;
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

		return db.execute(sql);
	}

	static findAll() {
		let sql = "SELECT * FROM user;";

		return db.execute(sql);
	}

	static findById(id) {
		let sql = `SELECT * FROM user WHERE user_id = ${id};`;

		return db.execute(sql);
	}

	static deleteById(id) {
		let sql = `DELETE * FROM user WHERE user_id = ${id};`;

		return db.execute(sql);
	}
}

module.exports = User;

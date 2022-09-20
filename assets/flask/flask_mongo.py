from flask import Flask
from flask import request
from pymongo import MongoClient

app = Flask(__name__)

client = MongoClient('localhost', 27017,
                     username='username', password='password')

db = client.flask_db
todos = db.todos


@app.route("/")
def home():
    return {"welcome": ["hello", "world", "!"]}


if __name__ == "__main__":
    app.run(debug=True)

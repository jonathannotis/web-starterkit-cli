from flask import Flask, request
import db

app = Flask(__name__)

db.init_db(app)

@app.route("/")
def home():
    return {"welcome": ["hello", "world", "!"]}

# Add routes here:

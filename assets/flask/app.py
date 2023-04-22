from flask import Flask, request
import db

app = Flask(__name__)

# Routing
@app.route("/")
def home():
    return {"welcome": ["hello", "world", "!"]}

# User routes
@app.route("/user", methods = ['GET', 'POST'])
def user():
    resp = {}
    # Get all users
    if request.method == 'GET':
        resp = db.get_users()
    elif request.method == 'POST':
        body = request.get_json(force = True)
        resp = db.add_user(body['email'], body['first_name'], body['last_name'])
    return resp

@app.route("/user/<id>", methods = ['GET', 'PUT', 'POST', 'DELETE'])
def user_by_id(id):
    resp = {}
    if request.method == 'GET':
        resp = db.get_users(id)
    # Note that POST and PUT are the same operation here because threre's an id filter.
    elif request.method in ['PUT', 'POST']:
        body = request.get_json(force = True)
        resp = db.update_user(id)
    elif request.method == ['DELETE']:
        resp = db.delete_user(id)
    return resp

# Add your routes here:

if __name__ == "__main__":
    app.run()

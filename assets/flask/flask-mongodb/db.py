from os import environ
from pymongo import MongoClient

client = MongoClient(environ.get('MONGODB_URI', "mongodb://localhost/web-starterkit"))

db = client.flask_db

def get_users(id = None):
    if (id == None):
        return db.users.find()
    return db.users.find({ "_id": id })

def add_user(email, first_name, last_name):
    if (email == None or first_name == None or last_name == None):
        return ValueError()
    return db.users.insert_one({'email': email, 'first_name': first_name, 'last_name': last_name})

def update_user(id, update):
    if (id == None):
        return ValueError()
    query = { "_id": id }
    newvalue = { "$set": update }
    return db.update_one(query, newvalue)

def delete_user(id):
    if (id == None):
        return ValueError()
    return db.delete_one({ "_id": id })
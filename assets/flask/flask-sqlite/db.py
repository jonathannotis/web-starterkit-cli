import flask_sqlalchemy
import os

def init_db(app):
    db = flask_sqlalchemy.SQLAlchemy()
    # For remote databases, replace this with an env variable containing the sql location for your 
    app.config['SQLALCHEMY_DATABASE_URI'] = f"sqlite:///{os.path.join(os.getcwd(), 'database.db')}"
    db.init_app(app)

# Add database functions here:
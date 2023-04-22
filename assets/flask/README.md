# Flask APIs

All APIs in the `flask` directory are hosted on Flask. There is an api using MongoDB and another using SQLite. Both use the same set of commands to setup and run the API:

## Running up the API

```bash
cd [directory_name]
# Create a python virtual environment and use it.
python3 -m venv env
source env/bin/activate
# Install Python packages using pip3.
pip3 install -r requirements.txt
```
To run the flask APIs, `flask run` in the directory.

## Setting environment variables

Each flask API comes with a `.flaskenv` file, which you can use to add and modify environment variables. This is where you will set your database URIs.
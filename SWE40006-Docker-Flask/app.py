from flask import Flask
import socket

app = Flask(__name__)


@app.route("/")
def home():
    hostname = socket.gethostname()

    return f"""
    <!DOCTYPE html>
    <html>
    <head>
        <title>SWE40006 Docker Application</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
                text-align: center;
                margin-top: 100px;
            }}

            .container {{
                max-width: 700px;
                margin: auto;
                padding: 40px;
                border: 1px solid #ddd;
                border-radius: 10px;
            }}

            h1 {{
                color: #333;
            }}

            .hostname {{
                font-family: monospace;
                background: #f4f4f4;
                padding: 10px;
                border-radius: 5px;
            }}
        </style>
    </head>

    <body>
        <div class="container">
            <h1>SWE40006 Docker Application</h1>
            <p>Python Flask application running inside a Docker container.</p>

            <p>Container hostname:</p>
            <div class="hostname">{hostname}</div>
        </div>
    </body>
    </html>
    """


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
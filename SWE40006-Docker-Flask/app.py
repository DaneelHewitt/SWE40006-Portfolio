from flask import Flask, jsonify
import os
import socket

app = Flask(__name__)

APP_NAME = os.getenv("APP_NAME", "SWE40006 Docker Application")
ENVIRONMENT = os.getenv("ENVIRONMENT", "development")
APP_VERSION = os.getenv("APP_VERSION", "1.0")

@app.route("/")
def home():
    hostname = socket.gethostname()

    return f"""
    <!DOCTYPE html>
    <html>
    <head>
        <title>{APP_NAME}</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background: #f4f4f4;
                margin: 0;
                padding: 40px;
            }}

            .container {{
                max-width: 800px;
                margin: auto;
                background: white;
                padding: 40px;
                border-radius: 12px;
                box-shadow: 0 4px 12px rgba(0,0,0,0.1);
            }}

            h1 {{
                margin-bottom: 10px;
            }}

            .status {{
                display: inline-block;
                padding: 8px 14px;
                background: #d4edda;
                color: #155724;
                border-radius: 6px;
                margin-bottom: 25px;
            }}

            .info {{
                padding: 15px;
                background: #f8f9fa;
                border-radius: 6px;
                margin-top: 10px;
            }}

            a {{
                color: #007bff;
                text-decoration: none;
            }}
        </style>
    </head>

    <body>
        <div class="container">
            <h1>{APP_NAME}</h1>

            <div class="status">
                Container running successfully
            </div>

            <h2>Deployment Information</h2>

            <div class="info">
                <strong>Environment:</strong> {ENVIRONMENT}
            </div>

            <div class="info">
                <strong>Application Version:</strong> {APP_VERSION}
            </div>

            <div class="info">
                <strong>Container Hostname:</strong> {hostname}
            </div>

            <div class="info">
                <strong>Application Port:</strong> 5000
            </div>

            <br>

            <p>
                This application has been containerized using Docker
                and deployed to an AWS EC2 Docker host.
            </p>

            <p>
                <a href="/health">View Health Check</a>
            </p>
        </div>
    </body>
    </html>
    """

@app.route("/health")
def health():
    return jsonify({
        "status": "healthy",
        "application": APP_NAME,
        "environment": ENVIRONMENT,
        "version": APP_VERSION,
        "hostname": socket.gethostname()
    })

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
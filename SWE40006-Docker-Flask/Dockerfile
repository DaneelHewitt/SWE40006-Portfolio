FROM python:3.12-slim

# Prevent Python from creating .pyc files and buffer stdout/stderr
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1

WORKDIR /app

# Install dependencies first to improve Docker layer caching
COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

# Copy application source
COPY app.py .

# Application configuration
ENV APP_NAME="SWE40006 Docker Application"
ENV ENVIRONMENT="production"
ENV APP_VERSION="2.0"

# Document the application port
EXPOSE 5000

# Run Flask application
CMD ["python", "app.py"]
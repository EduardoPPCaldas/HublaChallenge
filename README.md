
# Hubla Challenge

A web application to show and save sales using react and .NET 6


## Installation and Run

You can use docker-compose to run this application with:

```bash
  docker-compose up --build
```
There are 3 instances in the docker compose, an instance of postgres, 
the backend application writen in .NET 6
 and the frontend application using React with Vite
## Run Locally

When you run the docker-compose command the frontend will run in:

http://localhost:5015/

and the backend run in:

http://localhost:5015/
## Running Tests

The tests it's already in the Dockerfile script and runs when you build the application, you can see the logs in the terminal that you run the application


## API Reference

You can access http://localhost:5015/swagger/index.html 
to see a swagger documentation of the API


# Blog API

Web API for Blog Application

# EndPoints

GET /api/posts: This endpoint return a list of all posts, with their Titles, Content and the number of Comments associated with each post.

POST /api/posts: Create a new post.

GET /api/posts/{id}: Retrieve a specific post by its Id, including its Title, Content, and a list of associated Comments.

POST /api/posts/{id}/comments: Add a new Comment to a specific post.

# Solution

Used EntityFramework as ORM, with SQLServer database.

Used Swagger for API documentation.

Used Serilog for logging.

Created middleware to handle exceptions and log them.

Created Dtos as records, to avoid mutability and make the code more readable.

Used Dependency Injection to inject services and repositories.

Used Docker to run the application.

# How to run

Just need to run ```docker-compose up```

OpenAPI will be avialable in http://localhost:1357/swagger/index.html

# Database

For the first time its needed to run, inside the BlogAPI container, ```dotnet ef migrations add InitialCreate``` and ```dotnet ef database update```, to create and run first migration.

Database is accesible via ```localhost:1433``` or ```sqlserver:1433```.
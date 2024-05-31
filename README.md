# Book API with GraphQL Integration

This is a simple .NET WebAPI application with GraphQL integration that supports basic CRUD operations (Create, Read, Update, Delete) on a Book entity.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [GraphQL Endpoints](#graphql-endpoints)
- [Testing the API](#testing-the-api)

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another compatible database)

## Installation

1. **Clone the Repository**
    ```bash
    git clone https://github.com/noob-coder10/BookManagementApp.git
    cd BookManagementApp
    ```

2. **Restore NuGet Packages**
    ```bash
    dotnet restore
    ```

## Database Setup

1. **Configure Database Connection String**
   - Open `appsettings.json` and configure the connection string to your SQL Server database.
     ```json
     "ConnectionStrings": {
       "ConnectionString": "Server=server_name;Database=database_name;Trusted_Connection=True;TrustServerCertificate=True"
     }
     ```

2. **Apply Migrations**
   - Run the following command to apply the database migrations:
     ```bash
     cd BookManagementApp
     dotnet tool install --global dotnet-ef
     dotnet ef database update
     ```

## Running the Application

1. **Run the Application**
    ```bash
    dotnet run
    ```

2. **Access the API**
   - The API will be accessible at `http://localhost:7026`.

## GraphQL Endpoints

- **GraphQL Endpoint**
  - You can access the GraphQL endpoint at `http://localhost:7026/graphql`.

## Testing the API

You can test the API using tools like Banana Cake Pop, Postman or GraphQL Playground.

### Sample Queries and Mutations

**Query: Get All Books**
```graphql
query {
  allBooks {
    bookAuthor
    bookGenre
    bookId
    bookPublishedDate
    bookTitle
  }
}
```

**Query: Get a Single Book by its ID.**
```graphql
query {
  bookById(bookId: 1) {
    bookAuthor
    bookGenre
    bookId
    bookPublishedDate
    bookTitle
  }
}
```

**Mutation: Add a New Book**
1. **Set the GraphQL Variable as below:**
```json
{
  "addBook": {
    "bookTitle": "newTitle",
    "bookAuthor": "newAuthor",
    "bookPublishedDate": "2024-05-30T19:52:55.355Z",
    "bookGenre": "newGenre"
}
}
```
2.
```graphql
mutation ($addBook: AddBookRequestDtoInput!) {
  addBook(addBookRequestDto: $addBook) {
    bookAuthor
    bookGenre
    bookId
    bookPublishedDate
    bookTitle
  }
}
```

**Mutation: Update an Existing Book**
1. **Set the GraphQL Variable as below:**
```json
{
  "updateBook": {
    "bookTitleToBeUpdated": "updatedTitle",
    "bookAuthorToBeUpdated": "updatedAuthor",
    "bookGenreToBeUpdated": "updatedGenre"
  }
}
```
2.
```graphql
mutation ($updateBook: UpdateBookRequestDtoInput!) {
  updateBook(bookId: 9, updateBookRequestDto: $updateBook) {
    bookAuthor
    bookGenre
    bookId
    bookTitle
  }
}
```

**Mutation: Delete a Book**
```graphql
mutation {
  deleteBook(bookId: 1) {
    deletedBookId
    deletedBookTitle
  }
}
```


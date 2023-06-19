# NovoLibrary

NovoLibrary is a library management system offering core features such as managing book inventory, handling member data, and processing book borrow and return transactions.

## Getting Started

Clone this repository or download the project from [this link](https://github.com/Jensbol/NovoLibrary)

## Deployed Application

Access the deployed application from [this link](https://novolibraryapi.azurewebsites.net/swagger/index.html)

## Features

1. Book Management: Create, read, update, and delete (CRUD) operations for books.
2. Member Management: Create, read, update, and delete (CRUD) operations for members.
3. Borrowing and Returning Books: Handling of borrowing and returning of books, and listing borrowed books for a specified member.

## Technology Stack

- C#
- .NET Core 7
- Entity Framework Core
- MSSQL database
- XUnit and Moq for unit testing
- GitHub for version control

## Setup

Clone this repository using

```bash
git clone https://github.com/Jensbol/NovoLibrary.git.
```

Navigate to the project directory.
Install necessary packages with

```bash
dotnet restore
```

Build the project with

```bash
dotnet build
```

Run the project with

```bash
dotnet run
```

## How to run tests

I'm using XUnit as the testing framework.

1. Clone this repository to your local machine.
2. Navigate to the project directory in your terminal.
3. Run the following command:

```bash
dotnet test
```

## Assumptions and Decisions

While working on this project, several assumptions and decisions were made:

1. ReturnDate Interpretation: The returnDate attribute could be understood in two ways - either as the date the book should be returned when borrowed, or as the date to be filled when the book is returned. I have assumed the latter interpretation.
2. Hosting and Database: Azure is used as the hosting platform for this application, therefore it also made sense to use the Azure SQL server to host the database. The database used is a MSSQL database.
3. Test Coverage: Due to the time constraints, unit tests were written only for core business logic. Ideally, every method in the service layers would have corresponding unit tests to increase the test coverage of the application.
4. Swagger Documentation: The link to the application takes you directly to the swagger documentation. This is done on purpose to get a quick overview of the application and directly show the documentation.

## Trade-offs and Potential Improvements

While the application is functional, there were a few trade-offs made due to time constraints, and several areas were identified for potential improvement:

1. Input Validation: Currently, there is no validation of the input in the controllers. This should be added to prevent incorrect data entries.
2. Response Wrapping: The responses from the services could be wrapped in a standardized object for consistency and better error information.
3. Exception Handling: The current exception handling is basic and could be improved by implementing global exception handling, including null reference handling and create meaningful.
4. HTTP Status Codes: Proper use and handling of HTTP status codes can improve the API's usability and help identify issues quickly.
5. Testing: The test coverage could be improved by adding more unit tests, as well as integration and end-to-end tests.

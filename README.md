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

1. ReturnDate Interpretation: The attribute 'ReturnDate' can have two possible interpretations. It could represent the date by which a borrowed book is expected to be returned, or it could be the date to be filled when the book is actually returned. I opted for the first interpretation for the purpose of this project.
2. Hosting and Database: Azure is used as the hosting platform for this application, therefore it also made sense to use the Azure SQL server to host the database. The database used is a MSSQL database.
3. Test Coverage: I prioritized writing unit tests for the core business logic due to time constraints. However, a more comprehensive test coverage would involve writing more test scenarios and corresponding unit tests for every method in the service layers.
4. Swagger Documentation: The application link directly opens the Swagger documentation. This decision was made to facilitate quick API overview and provide immediate access to the API documentation.

## Trade-offs and Potential Improvements

There were a few compromises made during the development of the project and several areas were identified for potential enhancements::

1. Input Validation: Currently, there is a lack of input validation in the controllers. Implementing this can prevent erroneous data entries.
2. Response Wrapping: The responses from the services are not wrapped in a standard format. Adopting a consistent format for service responses can improve readability and error tracking.
3. Exception Handling: The current exception handling strategy is basic and lacks thoroughness. Implementing a comprehensive global exception handling strategy, including dealing with null references and meaningful custom exceptions, can improve the overall robustness of the application.
4. HTTP Status Codes: The application can benefit from a more strategic use and handling of HTTP status codes. This will enhance the usability of the API and provide more accurate error codes.
5. Testing: As mentioned earlier, the unit test coverage of the application could be significantly improved. The more the coverage, the more reliable the application would be.

# Technical Documentation (More detailed documentation can be found in the Documentation.docx file)

## Project Description

The web application project handling a contact list has been split into two separate applications:
- **ContactsApi**: An API enabling communication between the frontend application and the database. The API handles CRUD operations on records in the database.
- **ContactsApp**: Frontend application written using the MVVM pattern.

Unfortunately, the application does not support a login system, meaning that any user can add, edit, and delete contacts.

## Used Libraries

- Microsoft.EntityFramework
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.AspNetCore
- DotVVM.Framework

## Compilation Process

To compile the project, you need to first configure a local database. There are two ways to do this:
1. Import the Contacts.bacpac backup file included in the project.
2. Create a new table in an existing local database using the following SQL code:

```sql
CREATE TABLE Contacts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(50) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Password VARCHAR(45) NOT NULL
);

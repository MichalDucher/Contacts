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
# API Endpoints

| HTTP Method | Endpoint Path          | Description                                       |
|-------------|------------------------|---------------------------------------------------|
| GET         | /api/GetContacts       | Retrieves all records from the 'Contacts' table   |
| GET         | /api/GetContactById    | Retrieves a single record by the provided ID      |
| POST        | /api/InsertContact     | Adds a new record                                 |
| PUT         | /api/UpdateContact     | Updates a record with the provided ID             |
| DELETE      | /api/DeleteContact/{Id}| Deletes a record by the provided ID               |

## API Classes

### Program.cs
The main configuration file that adds controllers to handle HTTP requests and sets up the database connection.

### ContactsController.cs
The class handling requests from the client-side. It provides HTTP endpoints.

#### Methods:
- Constructor creating the database 'context'.
- `public async Task<ActionResult<List<Contact>>> Get()`: Retrieves all contacts from the database and returns the result as a list.
- `public async Task<ActionResult> GetUserById(int Id)`: Retrieves a single contact by the provided ID.
- `public async Task InsertContact(Contact contact)`: Adds a new contact to the database.
- `public async Task UpdateContact(Contact contact)`: Updates individual data about a single contact.
- `public async Task DeleteContact(int Id)`: Deletes a single contact by the provided ID.

### Contacts.cs
The class representing the contact model in the application. It contains fields for FirstName, LastName, Email, PhoneNumber, Category

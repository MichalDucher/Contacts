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
```
3. Then, run the API. In the ContactsApi project, in the appsettings.json file, there is a connection string to the database. You need to provide the server name where the database included in the project is located. After that, you can run the ContactsApp project.
# API Endpoints

| HTTP Method | Endpoint Path           | Description                                           |
|-------------|-------------------------|-------------------------------------------------------|
| GET         | /api/GetContacts        | Retrieves all records from the 'Contacts' table       |
| GET         | /api/GetContactById     | Retrieves a single record by the provided ID          |
| POST        | /api/InsertContact      | Adds a new record                                     |
| PUT         | /api/UpdateContact      | Updates a record with the provided ID                 |
| DELETE      | /api/DeleteContact/{Id} | Deletes a record by the provided ID                   |

# API Classes

## Program.cs
The main configuration file that adds controllers to handle HTTP requests and sets up the database connection.

## ContactsController.cs
The class handling requests from the client-side. It provides HTTP endpoints.

### Methods:
- Constructor creating the database 'context'.
- `public async Task<ActionResult<List<Contact>>> Get()`: Retrieves all contacts from the database and returns the result as a list.
- `public async Task<ActionResult> GetUserById(int Id)`: Retrieves a single contact by the provided ID.
- `public async Task InsertContact(Contact contact)`: Adds a new contact to the database.
- `public async Task UpdateContact(Contact contact)`: Updates individual data about a single contact.
- `public async Task DeleteContact(int Id)`: Deletes a single contact by the provided ID.

## Contacts.cs
The class representing the contact model in the application. It contains fields for FirstName, LastName, Email, PhoneNumber, Category, BirthDate, and Password.

## ContactsContext.cs
The class representing the database context in the application. It contains all information about entities and database configuration.

### Methods:
- Constructor accepting the context configuration object.
- `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)`: Configures the database connection.
- `protected override void OnModelCreating(ModelBuilder modelBuilder)`: Configures the data model.
- `partial void OnModelCreatingPartial(ModelBuilder modelBuilder)`: Partial method that can be used to configure the data model in other classes.

# ContactsApp - Classes

## Program.cs
This class is the entry point and starts the application.

### Methods:
- `public static void Main(string[] args)`: Starts the WebHost.
- `public static IWebHost BuildWebHost(string[] args)`: Creates an instance of the IWebHost class and points to the Startup.cs class as the class that configures the application.

## Startup.cs
This class represents the application configuration.

### Methods:
- `public void ConfigureServices(IServiceCollection services)`: Adds services such as AddWebEncoders, AddDbContext, and AddDotVVM.
- `public void Configure(IApplicationBuilder app, IWebHostEnvironment env)`: Defines the HTTP pipeline and adds middleware such as UseDeveloperExceptionPage, UseExceptionHandler, UseHttpsRedirection, UseHsts, UseStaticFiles, UseRouting, UseAuthentication, and UseAuthorization.

## ContactDetailModel.cs
The class representing the model of a single contact. It contains fields for Id, FirstName, LastName, Email, PhoneNumber, Category, Password, and BirthDate.

## ContactsListModel.cs
The class representing the model of a single contact displayed in the contact list. It contains fields for Id, FirstName, and LastName.

## ContactService.cs
This class contains methods that allow interaction with the web service. The class defines four methods that connect to the API and send requests to create, edit, or delete contacts.

### Methods:
- `public async Task<List<Contact>> GetAllContacts()`: Retrieves a list of all contacts.
- `public async Task GetContactById(int Id)`: Retrieves information about a single contact by the provided ID.
- `public async Task UpdateContact(ContactDetailModel contact)`: Updates data about a specific contact.
- `public async Task InsertContact(ContactDetailModel contact)`: Creates a new contact.
- `public async Task DeleteContact(int Id)`: Deletes a contact.

## CreateViewModel.cs, DetailViewModel.cs, EditViewModel.cs
These classes inherit from the MasterPageViewModel class and define the view model for the add, edit, and detail pages of a contact.

## DefaultViewModel.cs
The class defining the main view of the page.

### Methods:
- `public DefaultViewModel(ContactService contactService)`: Constructor accepting an object of the ContactService.cs class.
- `public override async Task PreRender()`: Retrieves a list of contacts, which is then displayed by DefaultViewModel.dothml.

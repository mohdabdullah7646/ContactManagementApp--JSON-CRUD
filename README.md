# Contact Management Application

- I used MySQL for the Database side.
- You can replace the connectionString in appsetting.json to run the application after cloning this repository in your local machine.


## Setup Instructions

### Prerequisites

- .NET v8.0 
- Angular v17.0
- MySQL
- Node.js command prompt


### Backend Setup (ContactManagementAPI)
1. Navigate to the backend project directory:
   ```sh
   cd ContactManagementApp/crud_operation-angular_dotnet_mysql/crud-dotnet-api

2. Restore the .NET dependencies:
   dotnet restore

3. Run the backend server:
   dotnet run



### Frontend Setup (ContactManagement)
1. Navigate to the frontend project directory:
   cd ContactManagementApp/crud_operation-angular_dotnet_mysql/crud-angular

2. Install the Angular dependencies:
   npm install

3. Run the Angular development server:
   ng serve 


### Running the Application
1. Ensure the backend server is running on http://localhost:5280 or https://localhost:7162.
2. Ensure the frontend server is running on http://localhost:4200.
3. Open a web browser and navigate to http://localhost:4200 to view the application.


### Design Decisions and Application Structure - ContactManagementApp
### Backend
1. Framework: .NET v8
2. Architecture: RESTful API
3. Data Storage: MySQL for Database
4. Error Handling: Global error handling to return appropriate responses

### Frontend
1. Framework: Angular v17
2. Styling: Bootstrap
3. State Management: RxJS
4. Forms: Angular Reactive Forms
5. Components Communication: @Input() and @Output() decorators for component interactions

### Database
1. MySQL: v8.0
2. DatabaseName: ContactDB
3. TableName: Employee
4. Fpr storing the data as well as for CRUD operations.

### Tests
- MS Unit Tests for .NET
- Jasmine/Karma Tests for Angular


### Application Structure
1. crud-dotnet-api/: Contains the .NET backend project.
2. crud-angular/: Contains the Angular frontend project.
3. README.md: Provides setup instructions, running instructions, and a brief explanation of design decisions and application structure.


### Branching Strategy
1. main: Contains the production-ready code.
2. development: Used for ongoing development and feature integration.
3. feature/*: Branches for individual features and bug fixes.   



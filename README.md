![elevator working](https://github.com/Jez02/Elevator/assets/173711586/41416d99-ccd4-4ced-afd7-d5544ff50b60)

Getting Started with Lift Assignment
Available Scripts
In the project directory, you can run:

Start the Application
Run the app in development mode:

bash
Copy code
Start
This will open the application in your default web browser, usually at http://localhost:5000 (adjust based on your project settings).

Set Up the Database
Create the Access Database:
Open Microsoft Access and create a new database named liftdb.accdb.
Create a table called LiftLog with the following structure:
ID (AutoNumber, Primary Key)
FloorNumber (Integer)
Timestamp (Date/Time)
Direction (Text)
Build the Application
Open Visual Studio:

Create a new Windows Forms App (.NET Framework) project named LiftAssignment.
Design the UI with the following elements:
A ComboBox for selecting floors.
Two Buttons labeled "Up" and "Down."
A Label for displaying the current floor.
An optional ListBox to show the lift’s movement log.
Add Database Connection:

Add a reference to System.Data.OleDb in your project.
Set up a connection string in your Form1.cs file:
csharp
Copy code
string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\liftdb.accdb";
Run the Application
Build and Run:
Click on the Start button in Visual Studio or press F5 to build and run the application.
The application will load, allowing you to select floors and log lift movements.
Log Lift Movements
Use the Up and Down Buttons:
Select a floor from the ComboBox.
Click the Up or Down button to log the lift's movement.
The current floor will be displayed in the Label and logged in the liftdb database.
Important Notes
Ensure that the Access Database Engine is installed for database connectivity.
If you encounter issues with database connections, verify the path to the database and table structure.

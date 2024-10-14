![elevator working](https://github.com/Jez02/Elevator/assets/173711586/41416d99-ccd4-4ced-afd7-d5544ff50b60)

Step 1: Create the liftdb Access Database
Open Microsoft Access and create a new database called liftdb.accdb.
Create a table called LiftLog with the following structure:
ID (AutoNumber, Primary Key)
FloorNumber (Integer) – Represents the selected floor.
Timestamp (Date/Time) – Records the time when the floor was selected.
Direction (Text) – Stores whether the lift is moving "Up" or "Down."
Save the table and close Access.
Step 2: Create a Windows Forms Application in Visual Studio
Open Visual Studio and create a new Windows Forms App (.NET Framework) project.
Name your project LiftAssignment.
In the Form Designer, design the interface for your lift. Here’s an example:
A ComboBox or Buttons to represent the floors (e.g., Floor 1, Floor 2, etc.).
Two Buttons for "Up" and "Down" directions.
A Label to show the current floor.
Optionally, a ListBox to display the movement log of the lift.

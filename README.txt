This Project is a master thesis project by Alexander Adelmann from Technical University of Graz.
The application analyses the context of the computer the user ic working on and then searches various data sources.
The results of the search are then shown in a Word 2013 Addin.

The project is runnable and doing its job, but there are lots of parts where it can be approved. 

Dev-Environment
Windows Server 2012 R2
MSSQL Express 2012 R2
Microsft Word 2013
Visual Studio 2015 Premium

Database setup:
The applications uses a MSSQL Database to store information. An empty database is located in the "DBBackup" directory.
To use the DB, restore it to a SQL Server and change the Connection string in the properties of the DAL Project inside the Logging Folder.

When the db is set up the application can be launched. The Word AddIn and the Core application are seperated applications. 
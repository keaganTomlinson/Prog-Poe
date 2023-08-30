
Prototype Web Application Readme
This readme file provides instructions on how to build and run the prototype web application developed by Keagan Tomlinson as part of the PROG7311 module. The web application is built using Visual Studio and C# and includes a database of farmers with their associated products. The application supports two different user roles: farmer and employee. Users are required to log in to access user-specific information. The website allows employees to add new farmers to the database, farmers to add new products to their 
profiles, and employees to view and filter the products supplied by a specific farmer based on date range or product type.
---------------------------------------------------------------
Requirements
To build and run the prototype web application, you will need the following:
Visual Studio: Download and install the latest version of Visual Studio from the official Microsoft website (https://visualstudio.microsoft.com/).
.NET Framework: Ensure that you have the .NET Framework installed. The application is developed using C# and requires the .NET Framework to run.
--------------------------------------------------------------------------------
Getting Started
Follow the steps below to build and run the prototype web application:
Clone the repository: Start by cloning this repository to your local machine.
Open the Project: Launch Visual Studio and open the cloned project from the repository.
Build Solution: Once the project is open in Visual Studio, build the solution to ensure that all dependencies are resolved. This step will compile the code and generate the necessary binaries.
Database Configuration: The project runs off of a hosted SQL Server; it does not require an update database command to run.
Run the Application: Start the web application by pressing F5 or clicking on the Run button in Visual Studio. This will launch a local development server and open the web application in your default web browser. Ensure that you have a stable internet connection to connect to your cloud-hosted SQL Server on Azure.
-------------------------------------------------------------------------------------------------------------------------------------------
Usage

The prototype web application provides the following functionality for different user roles:
Farmer
Log in: Navigate to the login page and enter your credentials as a farmer to access your profile and products.
Add a Product: After logging in, you can add a new product to your profile in the database. Click on the "Add Product" button, provide the necessary details, and submit the form.

Employee
Log in: Navigate to the login page and enter your credentials as an employee to access the administrative features.
Add a Farmer: Once logged in, you can add a new farmer to the database. Click on the "Add Farmer" button, enter the required information, and submit the form.
View Farmer's Products: After logging in, you can view the list of all the products supplied by a specific farmer. Click on the "View Products" button next to the farmer's name to see the products.
Filter Products: You can filter the displayed list of products supplied by a specific farmer according to the date range or product type. Use the provided filtering options to refine the results.
---------------------------------------------------------------------------------------------
Sample Data
The prototype web application includes sample data to demonstrate its functionality. The data is preloaded in the database and can be accessed by logging in with the provided farmer and employee credentials.
---------------------------------------------------------------------------------------------------------------
Login details:

Employee/Admin

Email: Admin@admin.com
Password: eBA$39B9Y34hMY#

Farmers

Email: john@farm4Life.com
Password: $YhVQpnTt3J_L*4

Email: keagantomlinson6@gmail.com
Password: NqZ9CUejPySYs!R
----------------------------------------------------------------------------------------------------------------------------
Feedback and Support
If you encounter any issues while building or running the prototype web application or have any questions, please feel free to contact Keagan Tomlinson at ST10084431@vcconnect.edu.za.





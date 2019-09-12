# Circles

#### _Discover new friends and build social circles - August 16, 2019_

#### _By **Na Hyung Choi, Kelar Crisp, Erik Irgens, and Emerson Jordan**_

## Description
Now hosted on azure:  

Circles - https://circlesapp.azurewebsites.net 

This Web site allows users to discover new friends and add them to private groups called circles. It uses the [Circles API](https://github.com/schoinh/circles-api).

The user can:
* Register a new account and log in
* Edit the user profile associated with the user's account
* Create "circles," which are private categories for grouping existing and potential friends (e.g. "Hiking")
* Browse other users' profiles and add them to circles

A user can only edit their own profile, and only view and edit their own circles.

## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:
    ```
    $ git clone https://github.com/erik-t-irgens/circles_mvc.git
    ```
2. Open the App Settings file (CIRCLES_MVC/appsettings.json) and ensure that the MySQL username and password match your MySQL credentials.

3. Log onto MySQL:
    ```
    $ mysql -u USERNAME -p PASSWORD
    ```
4. Navigate to the production folder (CIRCLES_MVC)
5. Restore dependencies, update your local database, and run the application
    ```
    $ dotnet restore
    $ dotnet ef database update
    $ dotnet run
    ```
7. On a Web browser (Chrome recommended), navigate to http://localhost:5002

## Known Bugs
None at this time.

## Technologies Used
* C# / .NET Core
* ASP.NET Core MVC
* ASP.NET Identity
* Entity Framework Core
* LINQ
* MySQL

## Support and contact details

_Please leave comments below with any feedback._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Na Hyung Choi, Kelar Crisp, Erik Irgens, and Emerson Jordan_**

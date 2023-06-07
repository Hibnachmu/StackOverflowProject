# StackOverflow project.

This is my C#.NET project that I have developing which is in close relation to the online website - stackoverflow.

## What this project actually is?

This project aims at developing a website which facilitates users to login, view questions and answers related to any coding category and write answers. 
The data of these questions and answers along with the identity of users and their activities such as voting will be stored in a database. 

## Features included till date:
Some of the building blocks and functionalities included in this project are:
 - The development was divided into 5 major segments - View Model, Domain Model, Repository, Front end development and Service layer.
 - The database was created using Microsoft Server Management studio 18.
 - Usage of Automapper to map the data between domain model and view model.
 - To protect the password in database using SHA256 Generator.
 
 ## Packages installed using the Nuget package manager:
 
 ```sh 
 install-package bootstrap
 ```
 
 ```sh
 install-package jQuery
 ```
 
 ```sh
 install-package popper.js
 ```
 
 ```sh
 install-package Microsoft.AspNet.Identity.EntityFramework
 ```
 
 ```sh
 install-package AutoMapper
 ```
 
 ## Future work:
 Some of the things that I'd be implementing soon would be:

- The different necessary controllers for users and admin along with their views.
- Wrtiting more business logic to facilitate voting by users.
- Creating admin and user workspace.

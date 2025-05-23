﻿README.md
Version: 1.0.0
(c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
https://creativecommons.org/licenses/by/4.0/

This work builds upon concepts and examples from:
"Get started with ASP.NET Core MVC | Microsoft Learn"
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio

I need your help, pray for me and support by checking out my music on YouTube:
https://youtube.com/shorts/Q921NmrtY9c
Please leave a good comment and like.


HISTORY
=======

STEP 7. Refactor the code
-------------------------
dotnet ef migrations add InitialCreate
dotnet ef database update



STEP 6. Add Comment Functionality
---------------------
dotnet ef migrations add InitialCreate --context ApplicationDbContext
dotnet ef database update --context ApplicationDbContext

dotnet ef migrations add AddMovieCatalogue --context MovieCatalogueDbContext
dotnet ef database update --context MovieCatalogueDbContext



STEP 5. Add User Data
---------------------

dotnet ef migrations add AddUserProfileFields --context ApplicationDbContext
dotnet ef database update --context ApplicationDbContext

dotnet ef migrations add AddComments --context MovieCatalogueDbContext
dotnet ef database update --context MovieCatalogueDbContext

STEP 4. Add Authentication
--------------------------

dotnet add package Microsoft.AspNetCore.Identity.UI -v 8.*
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 8.*
dotnet aspnet-codegenerator identity -dc MC01_0001.Data.ApplicationDbContext --files 
	"Account.Register;Account.Login;Account.Logout;
	 Account.Manage.Index;Account.Manage.ChangePassword;
	 Account.Manage.Email;Account.Manage.TwoFactorAuthentication;
	 Account.Manage.ExternalLogins"

dotnet ef migrations add InitialCreate  --context ApplicationDbContext
dotnet ef database update --context ApplicationDbContext

dotnet ef migrations add MovieCatalogueAddition --context MovieCatalogueDbContext
dotnet ef database update --context MovieCatalogueDbContext

STEP 3. Keep the database in sync with the model
------------------------------------------------
dotnet ef migrations add MovieDbContextUpdate, dotnet ef database update
dotnet ef migrations add MovieRatingUpdate, dotnet ef database update

STEP 2. Install ef core tools
-----------------------------
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef migrations add InitialCreate
dotnet ef database update

STEP 1. Open Powershell and run within project folder
-----------------------------------------------------
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

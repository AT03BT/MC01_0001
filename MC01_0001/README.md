Models/Movies.cs
Version: 1.0.0
(c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
https://creativecommons.org/licenses/by/4.0/


HISTORY
=======

STEP 3. Keep the database in sync with the model
------------------------------------------------
dotnet ef migrations add MovieDbContextUpdate

STEP 2. Install ef core tools
-----------------------------
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef migrations add InitialCreate
dotnet ef database update

STEP 1. Open Powershell and run within project folder
-----------------------------------------------------
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

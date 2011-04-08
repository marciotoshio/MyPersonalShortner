My Personal Shortner
====================

Dependencies
------------
* .NET Framework 4.0
* ASP.NET MVC 3
* SQL Server Compact 4.0 (for test with embedded database)
* EntityFramework 4.1.10311.0
* Unity 2.0
* NUnit 2.5.9.10348
* Moq 4.0.10827

Troubleshoot
------------
The ASP.Net MVC 3 project is using IIS Express as develop web server, if you have trouble with the project loading edit the csproj find any reference to UseIISExpress and set it to false.

The project uses SQL Server Compact 4.0 for tests if you want to use the normal Sql Server change the connection string to match your db and run SQlStart.sql
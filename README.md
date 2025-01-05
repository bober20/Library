This instractions are for Library ASP.Net Application.


To create a docker container run this command.
docker run -d 
--name shows_db
--network shows_db_network
--volume shows_db:/var/lib/postgresql/data 
-e POSTGRES_PASSWORD=12345678
-p 5432:5432
postgres


To enter the container use this command.
docker exec -it shows_db psql -U postgres


Inside the container run this command to create a database.
create database library_db;


After you have created a AppDbContext and added instructions to Program.cs (don't forget to install npgsql.EFC.PostgreSQL in nuget packages to work in Program.cs) execute migrations.

First of all install dotnet ef using the following command.
dotnet tool install --global dotnet-ef

Then install EF.Design.
dotnet add package Microsoft.EntityFrameworkCore.Design

Then execute migrations.=
dotnet ef migrations add initialMigration -s Library.API -p Library.DataAccess

To apply migration.
dotnet ef database update

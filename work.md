# Moeite om eerste migratie aan te maken
- dotnet ef werd niet gevonden tot ik dotnet tool install --global dotnet-ef uitvoerde.

- Foutmelding over DBContext bij uitvoeren op ItemService.Data.csproj : dotnet ef migrations add InitialCreate => Build started...
Build succeeded.
Unable to create an object of type 'AppDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728 .
API start wel:
PS D:\Repos\Temp\EFCoreApi\ItemService.API> dotnet run
Building...
warn: Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer[8]
      The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7052
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5052
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: D:\Repos\Temp\EFCoreApi\ItemService.API

- Toen geprobeerd op ItemService.Api.csproj, maar dat is blijkbaar niet de bedoeling.

- Oplossen met https://stackoverflow.com/a/63209624:
PS D:\Repos\Temp\EFCoreApi\ItemService.Data> dotnet ef --startup-project ..\ItemService.API\ migrations add InitialCreate
Build started...
Build succeeded.
Your startup project 'ItemService.API' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.

- Database aangemaakt!
'''PS D:\Repos\Temp\EFCoreApi\ItemService.Data> dotnet ef database update
Build started...
Build succeeded.
Unable to create an object of type 'AppDbContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728      
PS D:\Repos\Temp\EFCoreApi\ItemService.Data> dotnet ef --startup-project ..\ItemService.API\ database update
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (112ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [ItemService];
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (44ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [ItemService] SET READ_COMMITTED_SNAPSHOT ON;
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (11ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230717091412_InitialCreate'.
Applying migration '20230717091412_InitialCreate'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Items] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230717091412_InitialCreate', N'7.0.9');
Done.'''

# Sprint 2: Omzetten naar onion architecture

- Alles omgezet naar onion architecture. Klaar om nieuwe database aan te gaan maken met EFCore
- Initial create geslaagd:
PS D:\Repos\Temp\EFCoreApi\ItemService.Infrastructure> dotnet ef --startup-project ..\ItemService.API\ migrations add InitialCreateOnion
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'
PS D:\Repos\Temp\EFCoreApi\ItemService.Infrastructure> 
- Database succesvol aangemaakt:
PS D:\Repos\Temp\EFCoreApi\ItemService.Infrastructure> dotnet ef --startup-project ..\ItemService.API\ database update
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (223ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [ItemServiceOnion];
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (53ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [ItemServiceOnion] SET READ_COMMITTED_SNAPSHOT ON;
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230719175924_InitialCreateOnion'.
Applying migration '20230719175924_InitialCreateOnion'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Items] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230719175924_InitialCreateOnion', N'7.0.9');
Done.
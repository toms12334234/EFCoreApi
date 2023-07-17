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
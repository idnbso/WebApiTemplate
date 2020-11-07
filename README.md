# WebApiTemplate

### Project Setup
- .NET 4.8 Web API Project
  * Create new Empty project in Visual Studio
	* Select Web API in "Add folders & core references"
- Setup Development Environments
  * Add App Settings to Web.config file
  * Add Configurations directory for all three environments with app settings
	* local
	* dev
	* prod
- [Add Database Connection String to App Settings in Web.config](https://blog.elmah.io/the-ultimate-guide-to-connection-strings-in-web-config/)
- JSON
  * [Configure to return JSON only](https://stackoverflow.com/questions/12629144/how-to-force-asp-net-web-api-to-always-return-json)
  * [Add JSON support with camelCase](https://stackoverflow.com/questions/28552567/web-api-2-how-to-return-json-with-camelcased-property-names-on-objects-and-the)
- [Configure CORS](https://enable-cors.org/server_aspnet.html)
- [AutoFac & AutoMapper](https://dev.to/willydavidjr/how-to-integrate-autofac-5-and-automapper-10-on-your-mvc-5-project-using-visual-studio-2019-2190)
  * [Install Autofac.WebApi2 NuGet](https://www.nuget.org/packages/Autofac.WebApi2/)
  * [Install AutoMapper NuGet](https://www.nuget.org/packages/AutoMapper/)
- Serilog
  * [Configuration](https://medium.com/@matthew.bajorek/configuring-serilog-in-asp-net-core-2-2-web-api-5e0f4d89749c)
  * NuGet Packages
	- Serilog
    - Serilog.Sinks.File
    - Serilog.Sinks.Async
    - Serilog.Formatting.Compact
    - Serilog.Enrichers.Thread
    - Serilog.Exceptions
    - SerilogWeb.Classic.WebApi
- Dapper
  - [Install Dapper.SimpleCRUD NuGet](https://www.nuget.org/packages/Dapper.SimpleCRUD)
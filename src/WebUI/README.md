## Presentation Layer

The WebUI project represents the Presentation layer. 
This project is a SPA (single page app) based on Angular 8 and ASP.NET Core. 
This layer depends on both the Application and Infrastructure layers. 

Please note the dependency on Infrastructure is only to support dependency injection. 
Therefore Startup.cs should include the only reference to Infrastructure.

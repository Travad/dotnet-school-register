// 1. Initialize the WebApplicationBuilder and add all the require endpoints for the
//      SchoolRegister API. The builder gives access to the Services,
//      Configuration properties and Environment variables.
var builder = WebApplication.CreateBuilder(args).AddSchoolRegisterServices();

// 2. The application is built and the (minimal) endpoints are mapped to the app
await using var app = builder.Build().UseSchoolRegisterServices();

// 3. Await the application run
await app.RunAsync();
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Api.Data.Contexts;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: TestFramework(
    "SchoolRegister.Api.Tests.Integration.SchoolRegisterTestRunStart", 
    "SchoolRegister.Api.Tests.Integration")]
namespace SchoolRegister.Api.Tests.Integration;

public class SchoolRegisterTestRunStart : XunitTestFramework
{
    public SchoolRegisterTestRunStart(IMessageSink messageSink) : base(messageSink)
    {
        // Database
        var options = new DbContextOptionsBuilder<SchoolRegisterDbContext>()
            .UseSqlite("DataSource=file:inmem?mode=memory&cache=shared")
            .Options;
        
        var dbContext = new SchoolRegisterDbContext(options);
        dbContext.Database.Migrate();
    }
}
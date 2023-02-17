using Microsoft.EntityFrameworkCore;
using SchoolRegister.Api.Data.Contexts;
using Xunit.Abstractions;
using Xunit.Sdk;


[assembly: Xunit.TestFramework(
    "SchoolRegister.Api.Tests.Integration.SchoolRegisterTestRunStart", 
    "SchoolRegister.Api.Tests.Integration")]
namespace SchoolRegister.Api.Tests.Integration;

public class SchoolRegisterTestRunStart : XunitTestFramework
{
    public SchoolRegisterTestRunStart(IMessageSink messageSink) : base(messageSink)
    {
        var options = new DbContextOptionsBuilder<SchoolRegisterDbContext>()
            .UseSqlite("DataSource=file:inmem?mode=memory&cache=shared");
        var dbContext = new SchoolRegisterDbContext(options.Options);
        dbContext.Database.Migrate();
    }
}
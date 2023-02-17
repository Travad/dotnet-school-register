using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolRegister.Api.Data.Contexts;

namespace SchoolRegister.Api.Tests.Integration;

public class SchoolRegisterApiFactory : WebApplicationFactory<ISchoolRegisterApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var options = new DbContextOptionsBuilder<SchoolRegisterDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            services.AddSingleton(options);
            services.AddSingleton<SchoolRegisterDbContext>();
        });
    }
}
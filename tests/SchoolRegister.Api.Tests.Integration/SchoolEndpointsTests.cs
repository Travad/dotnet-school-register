using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SchoolRegister.Api.Tests.Integration;

public class SchoolEndpointsTests : IClassFixture<SchoolRegisterApiFactory>
{
    private readonly SchoolRegisterApiFactory _factory;

    public SchoolEndpointsTests(SchoolRegisterApiFactory factory)
    {
        // Inject a (modified) test server
        _factory = factory;
    }

    [Fact]
    public async Task GetAllSchools_ReturnsAllSchools()
    {
        // Act
        var httpClient = _factory.CreateClient();
        var result = await httpClient.GetAsync("/schools");
        // var schools = await result.Content.ReadFromJsonAsync<IEnumerable<SchoolDto>>();
        
        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        // schools.Should().NotBeEmpty();
    }
}
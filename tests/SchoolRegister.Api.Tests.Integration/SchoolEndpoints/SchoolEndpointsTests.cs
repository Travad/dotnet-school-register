using SchoolRegister.Api.Entities;

namespace SchoolRegister.Api.Tests.Integration.SchoolEndpoints;

public partial class SchoolEndpointsTests : 
    IClassFixture<SchoolRegisterApiFactory>,
    IAsyncLifetime
{
    private readonly SchoolRegisterApiFactory _factory;
    private readonly List<int> _schoolIds = new();

    public SchoolEndpointsTests(SchoolRegisterApiFactory factory)
    {
        // Inject a (modified) test server
        _factory = factory;
    }
    
    private School GenerateSchool(Location? location, List<Course>? courses) =>
        new School()
        {
            Id = 1000,
            Name = "Test School",
            Description = "Test Description",
            DateOfConstruction = new DateTime(1997, 1, 1),
            LocationSchool = location,
            LocationSchoolId = location?.Id,
            Courses = courses?? new List<Course>(),
            Email = "testmail@gmail.com",
            PhoneNumber = "000000000",
        };

    public async Task InitializeAsync() => await Task.CompletedTask;

    public async Task DisposeAsync()
    {
        var httpClient = _factory.CreateClient();

        foreach (var schoolId in _schoolIds)
        {
            await httpClient.DeleteAsync($"/schools/{schoolId}");
        }
    }
    private record ValidationErrors(string PropertyName, string ErrorMessage);
}


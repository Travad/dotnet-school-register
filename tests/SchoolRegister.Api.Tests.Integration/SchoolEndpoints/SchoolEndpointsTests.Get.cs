using System.Net;
using System.Net.Http.Json;
using SchoolRegister.Api.Entities;
using SchoolRegister.Api.Models.Dto.School;

namespace SchoolRegister.Api.Tests.Integration.SchoolEndpoints;

public partial class SchoolEndpointsTests
{
        // <summary>
    // 200: OK - The request has succeeded.
    // </summary>
    [Fact]
    public async Task GetAllSchools_ReturnsAllSchools_WhenDataIsLoaded()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        
        // Act
        var result = await httpClient.GetAsync("/schools");
        var schools = await result.Content.ReadFromJsonAsync<IEnumerable<SchoolDto>>();

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        schools.Should().NotBeEmpty();
    }

    /// <summary>
    /// 200: Ok: The server returns the specific list of assets that match the search!
    /// </summary>
    [Fact]
    public async Task GetAllSchools_ReturnsASpecificSchool_WhenSearchTermIsValid()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null,null);
        _schoolIds.Add(school.Id);
        string searchTerm = "Test";
        
        // Act
        await httpClient.PostAsJsonAsync("/schools", school);

        // Act
        var getRequest = await httpClient.GetAsync($"/schools?searchTerm={searchTerm}");
        var getResult = await getRequest.Content.ReadFromJsonAsync<IEnumerable<School>>();
        var result = getResult!.Single();
        result.Id = school.Id;
        
        // Assert
        getRequest.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEquivalentTo(school);
    }

    // <summary>
    // 200: OK - The request has succeeded.
    // </summary>
    [Fact]
    public async Task GetSchool_ShouldReturnSchool_WhenIdIsValid()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        _schoolIds.Add(school.Id);
        
        // Act
        await httpClient.PostAsJsonAsync<School>("/schools", school);
        var getRequest = await httpClient.GetAsync($"/schools/{school.Id}");
        var returnedSchool = await getRequest.Content.ReadFromJsonAsync<School>();
        returnedSchool!.Id = school.Id; // TODO: fix this with AutoMapper (as we need to test DTOs)
        
        // Assert
        getRequest.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedSchool.Should().BeEquivalentTo(school);
    }
    
    // <summary>
    // 404: Not Found - The server can not find the requested resource (not existing).
    // </summary>
    [Fact]
    public async Task GetSchool_ShouldNotReturnSchool_WhenSchoolDoesNotExists()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);

        // Act
        var getRequest = await httpClient.GetAsync($"/schools/{school.Id}");

        // Assert
        getRequest.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
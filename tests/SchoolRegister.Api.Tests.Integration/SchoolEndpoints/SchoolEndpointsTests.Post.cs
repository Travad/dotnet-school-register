using System.Net;
using System.Net.Http.Json;
using SchoolRegister.Api.Entities;

namespace SchoolRegister.Api.Tests.Integration.SchoolEndpoints;

public partial class SchoolEndpointsTests
{
    /// <summary>
    /// 201: Created - The request has been fulfilled and resulted in a new resource being created.
    /// </summary>
    [Fact]
    public async Task CreateSchool_ShouldCreateSchool_WhenDataIsCorrect()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        
        // Act
        var postRequest = await httpClient.PostAsJsonAsync<School>("/schools", school);
        var createdSchool = await postRequest.Content.ReadFromJsonAsync<School>();
        _schoolIds.Add(school.Id);

        // Assert
        postRequest.StatusCode.Should().Be(HttpStatusCode.Created);
        createdSchool.Should().BeEquivalentTo(school);
        postRequest.Headers.Location.Should().Be($"{httpClient.BaseAddress}schools/{school.Id}");
    }

    /// <summary>
    /// 400: Bad Request - The server cannot or will not process the request due to something that is perceived to be a client error.
    /// </summary>
    [Fact]
    public async Task CreateSchool_ShouldNotCreateSchool_WhenDataIsInvalid()
    {
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        school.Name = null;
        
        // Act
        var postRequest = await httpClient.PostAsJsonAsync<School>("/schools", school);
        var errors = await postRequest.Content.ReadFromJsonAsync<IEnumerable<ValidationErrors>>();
        var error = errors!.First();
        
        // Assert
        postRequest.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.PropertyName.Should().BeEquivalentTo("Name");
        error.ErrorMessage.Should().BeEquivalentTo("Name field is required");
    }

    /// <summary>
    /// 409: Conflict - Indicates that the request could not be processed because of conflicts, such as identical assets already present.
    /// </summary>
    [Fact]
    public async Task CreateSchool_ShouldNotCreateSchool_WhenSchoolAlreadyExists()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        _schoolIds.Add(school.Id);
        
        // Act
        var postRequest = await httpClient.PostAsJsonAsync<School>("/schools", school); // fine
        var postRequestRepeated = await httpClient.PostAsJsonAsync<School>("/schools", school); // not fine
        var errors = await postRequestRepeated.Content.ReadFromJsonAsync<IEnumerable<ValidationErrors>>();
        var error = errors!.Single();
        
        // Assert
        postRequest.StatusCode.Should().Be(HttpStatusCode.Created);
        postRequestRepeated.StatusCode.Should().Be(HttpStatusCode.Conflict);
        error.PropertyName.Should().BeEquivalentTo("Id");
        error.ErrorMessage.Should().BeEquivalentTo($"The resource with Id {school.Id} already exists!");
    }
    
}
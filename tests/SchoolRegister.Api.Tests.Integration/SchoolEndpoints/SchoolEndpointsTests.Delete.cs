using System.Net;
using System.Net.Http.Json;

namespace SchoolRegister.Api.Tests.Integration.SchoolEndpoints;

public partial class SchoolEndpointsTests
{
    
    /// <summary>
    /// 204 - NoContent: The resource was deleted correctly
    /// </summary>
    [Fact]
    public async Task DeleteSchool_ShouldDeleteSchool_WhenSchoolExists()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null,null);
        _schoolIds.Add(school.Id);
        
        // Act
        await httpClient.PostAsJsonAsync("/schools", school);
        
        // Act
        var deleteRequest = await httpClient.DeleteAsync($"schools/{school.Id}");
        
        // Assert
        deleteRequest.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    /// <summary>
    /// 404 - NotFound: The resource was not present in the backend
    /// </summary>
    [Fact]
    public async Task DeleteSchool_ShouldNotDeleteSchool_WhenSchoolDoesNotExist()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        
        // Act
        var deleteRequest = await httpClient.DeleteAsync($"schools/{Int32.MaxValue}");
        
        // Assert
        deleteRequest.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
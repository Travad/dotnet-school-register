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
    public async Task ModifySchool_ShouldModifySchool_WhenDataIsCorrect()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        
        // Act
        var postRequest = await httpClient.PostAsJsonAsync<School>("/schools", school);
        _schoolIds.Add(school.Id);
        
        // Act
        school.Name = "Modified school name";
        var putRequest = await httpClient.PutAsJsonAsync<School>($"/schools", school);
        
        // Act
        var getRequest = await httpClient.GetAsync($"/schools/{school.Id}");
        var modifiedSchool = await getRequest.Content.ReadFromJsonAsync<School>();
        modifiedSchool.Id = school.Id;

        // Assert
        putRequest.StatusCode.Should().Be(HttpStatusCode.OK);
        modifiedSchool.Should().BeEquivalentTo(school);
        postRequest.Headers.Location.Should().Be($"{httpClient.BaseAddress}schools/{school.Id}");
    }
    
    /// <summary>
    /// 400: Bad Request - The server cannot or will not process the request due to something that is perceived to be a client error.
    /// </summary>
    [Fact]
    public async Task ModifySchool_ShouldNotModifySchool_WhenDataIsInvalid()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null, null);
        
        // Act
        var postRequest = await httpClient.PostAsJsonAsync<School>("/schools", school);
        _schoolIds.Add(school.Id);
        
        // Act
        school.Name = null;
        var putRequest = await httpClient.PutAsJsonAsync<School>($"/schools", school);
        var errors = await putRequest.Content.ReadFromJsonAsync<IEnumerable<ValidationErrors>>();
        var error = errors!.First();
        
        // Assert
        putRequest.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        error.PropertyName.Should().BeEquivalentTo("Name");
        error.ErrorMessage.Should().BeEquivalentTo("Name field is required");
    }
    
    /// <summary>
    /// 404: NotFound - The request to the server goes invalid as the school is not found
    /// </summary>
    [Fact]
    public async Task ModifySchool_ShouldNotModifySchool_WhenSchoolDoesNotExist()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null,null);

        // Act
        await httpClient.PostAsJsonAsync("/schools", school);
        
        // Act
        school.Id = new Random().Next(2_000, 3_000);
        var putRequest = await httpClient.PutAsJsonAsync("/schools", school);

        // Assert
        putRequest.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
}
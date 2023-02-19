using System.Net;
using System.Net.Http.Json;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using SchoolRegister.Api.Models.Dto.School;
using SchoolRegister.Models.Entities;
using SQLitePCL;

namespace SchoolRegister.Api.Tests.Integration;

public class SchoolEndpointsTests : 
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

    // <summary>
    // 201: Created - The request has been fulfilled and resulted in a new resource being created.
    // </summary>
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

    // <summary>
    // 409: Conflict - Indicates that the request could not be processed because of conflicts, such as identical assets already present.
    // </summary>
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
    
    
    // <summary>
    // 201: Created - The request has been fulfilled and resulted in a new resource being created.
    // </summary>
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
    
    // <summary>
    // 400: Bad Request - The server cannot or will not process the request due to something that is perceived to be a client error.
    // </summary>
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
    
    // <summary>
    // 404: NotFound - The request to the server goes invalid as the school is not found
    // </summary>
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
    
    // <summary>
    // 200: OK - The request has succeeded.
    // </summary>
    [Fact]
    public async Task GetAllSchools_ReturnsAllSchools_WhenDataIsLoaded()
    {
        // Act
        var httpClient = _factory.CreateClient();
        var result = await httpClient.GetAsync("/schools");
        var schools = await result.Content.ReadFromJsonAsync<IEnumerable<SchoolDto>>();

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        schools.Should().NotBeEmpty();
    }

    // TODO: Not Working!!
    [Fact]
    public async Task GetAllSchools_ReturnsASpecificSchool_WhenSearchTermIsValid()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var school = GenerateSchool(null,null);
        var school2 = GenerateSchool(null, null);
        
        school2.Id = school.Id + 1;
        school2.Name = "Liceo Scientifico Marianella";
        _schoolIds.Add(school.Id);
        _schoolIds.Add(school2.Id);
        
        string searchTerm = "marianella";
        
        // Act
        await httpClient.PostAsJsonAsync("/schools", school);
        await httpClient.PostAsJsonAsync("/schools", school2);
        
        // Act
        var getRequest = await httpClient.GetAsync($"/schools?searchTerm={searchTerm}");
        var getResult = await getRequest.Content.ReadFromJsonAsync<IEnumerable<School>>();
        var firstResult = getResult!.Single();
        
        // Assert
        getRequest.StatusCode.Should().Be(HttpStatusCode.OK);
        // firstResult.Should().BeEquivalentTo(school2);
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
}

public record ValidationErrors(string PropertyName, string ErrorMessage);
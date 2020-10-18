using FluentAssertions;
using Sweepi.UserServiceAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Sweepi.UserServiceAPI.Models;
using Sweepi.UserServiceAPI.Contollers;
using Sweepi.UserServiceAPI.Data;
using Moq;

namespace Sweepi.UserServiceAPI.IntegrationTests
{
  public class UserServiceControllerTests : IClassFixture<WebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Startup> _factory;

    public UserServiceControllerTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    } 

    [Fact]
    public async Task Get_Should_Return_Ok_Result()
    {
      var response = await _client.GetAsync("/api/users");
      response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    [Fact]
    public async Task Get_By_Id_Should_Return_Ok_Result()
    {
      var response = await _client.GetAsync("/api/users/test-test");
      response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    [Fact]
    public async Task Get_By_Id_Should_Return_User_With_Id()
    {
      
    }
    [Fact]
    public async Task Get_By_Id_Should_Return_User_Not_Found()
    {

    }
    [Fact]
    public async Task Put_Should_Return_No_Content_Result()
    {

    }
    [Fact]
    public async Task Put_Should_Return_Bad_Request_Result()
    {

    }
    [Fact]
    public async Task Post_Should_Return_Created_Result()
    {

    }
    [Fact]
    public async Task Delete_Should_Return_Not_Found_Result()
    {

    }
    [Fact]
    public async Task Delete_Should_Return_No_Content_Result()
    {

    }
    [Fact]
    public async Task Post_Should_Return_Bad_Request_Result()
    {

    }
    
  }
}
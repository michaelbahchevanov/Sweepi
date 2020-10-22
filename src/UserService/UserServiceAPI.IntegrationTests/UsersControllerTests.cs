using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sweepi.UserServiceAPI.IntegrationTests
{
    public class UsersControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_Should_Return_Ok_Response()
        {
            var response = await TestClient.GetAsync("/api/users");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetById_Should_Return_NotFound_Where_User_Is_Null()
        {
            var response = await TestClient.GetAsync("/api/users/nonexistinguser");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}

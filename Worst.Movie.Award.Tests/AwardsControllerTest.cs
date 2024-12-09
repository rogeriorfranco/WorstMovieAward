using Microsoft.AspNetCore.Mvc.Testing;

namespace Worst.Movie.Award.Tests
{
    public class AwardsControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async Task GetAwards_Returns_CorrectData()
        {
            var app = new CustomWebApplicationFactory();
            var client = app.CreateClient();
            var response = await client.GetAsync("https://localhost:8080/api/awards");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("\"min\"", content);
            Assert.Contains("\"max\"", content);
        }
    }
}

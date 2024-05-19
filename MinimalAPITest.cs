using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MinimalAPI_Test
{
    public class MinimalAPITest
    {
        [Fact]
        public async void GetAllBooksTest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/book");
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
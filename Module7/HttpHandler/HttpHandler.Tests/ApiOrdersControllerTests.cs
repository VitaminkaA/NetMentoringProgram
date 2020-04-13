using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace HttpHandler.Tests
{
    public class ApiOrdersControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ApiOrdersControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("CHOPS", null, null, null, null)]
        public async Task GetOrders_GetQuery_ReturnJSON(string id, DateTime? dateRangeFrom, DateTime? dateRangeTo, int? skip, int? take)
        {
            //Act
            const string expectedMediaType = "application/json";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(expectedMediaType));
            var orders = await _client.GetAsync($"api/Orders/Get?customerId={id}");

            //Assert
            Assert.NotNull(orders);
            Assert.True(orders.IsSuccessStatusCode);
            Assert.Equal(expectedMediaType, orders.Content.Headers.ContentType.MediaType);
        }

        [Theory]
        [InlineData("CHOPS", null, null, null, null)]
        public async Task GetOrders_PostQuery_ReturnXML(string id, DateTime? dateRangeFrom, DateTime? dateRangeTo, int? skip, int? take)
        {
            //Act
            const string expectedMediaType = "application/xml";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(expectedMediaType));
            var orders = await _client.GetAsync($"api/Orders/Get?customerId={id}");

            //Assert
            Assert.NotNull(orders);
            Assert.True(orders.IsSuccessStatusCode);
            Assert.Equal(expectedMediaType, orders.Content.Headers.ContentType.MediaType);
        }

        [Theory]
        [InlineData("CHOPS", null, null, null, null)]
        public async Task GetOrders_PostQuery_ReturnExcel(string id, DateTime? dateRangeFrom, DateTime? dateRangeTo, int? skip, int? take)
        {
            //Act
            const string expectedMediaType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(expectedMediaType));
            var orders = await _client.GetAsync($"api/Orders/Get?customerId={id}");

            //Assert
            Assert.NotNull(orders);
            Assert.True(orders.IsSuccessStatusCode);
            Assert.Equal(expectedMediaType, orders.Content.Headers.ContentType.MediaType);
        }
    }
}

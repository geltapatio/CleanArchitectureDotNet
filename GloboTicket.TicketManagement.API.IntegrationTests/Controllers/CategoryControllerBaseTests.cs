
using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Controllers
{

    public class CategoryControllerBaseTests : ControllerBaseTest
    {
        public CategoryControllerBaseTests(CustomWebApplicationFactory<Program> factory, string baseControllerRoute = "/api/category") : base(factory, baseControllerRoute) { }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var response = await SendGetRequest("/all");

            response.EnsureSuccessStatusCode();

            var result = await GetResponseResults<CategoryListVm>(response);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}

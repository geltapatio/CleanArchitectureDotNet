
using CleanArchitecture.DotNet6.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitecture.DotNet6.API.IntegrationTests.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.DotNet6.API.IntegrationTests.Controllers
{

    public class CategoryControllerBaseTests : ControllerBaseTest
    {
        public CategoryControllerBaseTests(CustomWebApplicationFactory<Program> factory, string baseControllerRoute = "/api/category") : base(factory, baseControllerRoute) { }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            System.Net.Http.HttpResponseMessage response = await SendGetRequest("/all");

            response.EnsureSuccessStatusCode();

            List<CategoryListVm> result = await GetResponseResults<CategoryListVm>(response);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}

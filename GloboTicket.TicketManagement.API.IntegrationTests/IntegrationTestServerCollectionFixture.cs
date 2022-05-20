using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using Xunit;

namespace GloboTicket.TicketManagement.API.IntegrationTests
{
    [CollectionDefinition(nameof(IntegrationTestServerCollectionFixture))]
    public class IntegrationTestServerCollectionFixture : ICollectionFixture<CustomWebApplicationFactory<Program>> { }
}

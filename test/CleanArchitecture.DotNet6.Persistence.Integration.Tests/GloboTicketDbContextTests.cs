using CleanArchitecture.DotNet6.Application.Contracts;
using CleanArchitecture.DotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace CleanArchitecture.DotNet6.Persistence.Integration.Tests
{
    public class CleanArchitectureDbContextTests
    {
        private readonly CleanArchitectureDbContext _CleanArchitectureDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public CleanArchitectureDbContextTests()
        {
            DbContextOptions<CleanArchitectureDbContext>? dbContextOptions = new DbContextOptionsBuilder<CleanArchitectureDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _CleanArchitectureDbContext = new CleanArchitectureDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            Event? ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _CleanArchitectureDbContext.Events.Add(ev);
            await _CleanArchitectureDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}

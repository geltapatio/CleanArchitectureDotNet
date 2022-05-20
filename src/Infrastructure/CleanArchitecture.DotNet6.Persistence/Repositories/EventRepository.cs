using CleanArchitecture.DotNet6.Application.Contracts.Persistence;
using CleanArchitecture.DotNet6.Domain.Entities;

namespace CleanArchitecture.DotNet6.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            bool matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
}

using CleanArchitecture.DotNet6.Domain.Entities;

namespace CleanArchitecture.DotNet6.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}

using CleanArchitecture.DotNet6.Domain.Entities;

namespace CleanArchitecture.DotNet6.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}

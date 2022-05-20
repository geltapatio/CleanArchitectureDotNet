using CleanArchitecture.DotNet6.Application.Contracts.Persistence;
using CleanArchitecture.DotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.DotNet6.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            List<Category>? allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}

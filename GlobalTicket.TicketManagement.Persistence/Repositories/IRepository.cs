namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public interface IRepository : IReadOnlyRepository
    {
        public void Create<TEntity>(TEntity entity, string? createdBy = null)
            where TEntity : class, IEntity;

        public void Update<TEntity>(TEntity entity, string? modifiedBy = null)
            where TEntity : class, IEntity;

        public void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        public void Save();

        public Task SaveAsync();
    }
}

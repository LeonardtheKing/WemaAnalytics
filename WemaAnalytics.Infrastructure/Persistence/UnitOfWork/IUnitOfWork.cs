namespace WemaAnalytics.Infrastructure.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IVisitRepository VisitRepository { get; }
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

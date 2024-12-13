namespace WemaAnalytics.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork(SqlDbContext sqlDbContext) : IUnitOfWork
    {
        private readonly SqlDbContext _sqlDbContext = sqlDbContext;
        private IDbContextTransaction? _transaction;
        private IVisitRepository? _visits;
        
        public IVisitRepository VisitRepository => _visits ??= new VisitRepository(_sqlDbContext.Visits);

        public async Task BeginTransactionAsync(CancellationToken cancellation)
        {
            _transaction = await _sqlDbContext.Database.BeginTransactionAsync(cancellation);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int result = await _sqlDbContext.SaveChangesAsync(cancellationToken);
                if (_transaction != null)
                {
                    await _transaction.CommitAsync(cancellationToken);
                }
                return result;
            }
            catch
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
        }

        private async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _sqlDbContext.Dispose();
            _transaction?.Dispose();
        }
    }
}

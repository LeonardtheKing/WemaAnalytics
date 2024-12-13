namespace WemaAnalytics.Infrastructure.Persistence.Repositories
{
    public class VisitRepository(DbSet<Visit> visits) : RepositoryBase<Visit>(visits), IVisitRepository
    {
        private readonly DbSet<Visit> _visits = visits;

        public async Task<PagedList<Visit>> GetAllPaginated(VisitParams @params, CancellationToken cancellationToken)
        {
            IQueryable<Visit> query = _visits.AsNoTracking().Where(v => v.IsDeleted == false);

            if (!string.IsNullOrEmpty(@params.StaffEmail))
            {
                query = query.Where(v => v.StaffEmail == @params.StaffEmail);
            }

            query = query.OrderByDescending(v => v.Date).ThenByDescending(v => v.Time);

            return await PagedList<Visit>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize, cancellationToken);
        }
    }
}

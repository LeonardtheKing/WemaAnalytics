namespace WemaAnalytics.Domain.Repositories
{
    public interface IVisitRepository : IRepositoryBase<Visit>
    {
        // Add Special Methods Not Provided By IRepositoryBase
        Task<PagedList<Visit>> GetAllPaginated(VisitParams @params, CancellationToken cancellationToken);
    }
}

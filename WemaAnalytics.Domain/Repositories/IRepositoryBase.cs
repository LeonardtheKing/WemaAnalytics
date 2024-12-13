﻿namespace WemaAnalytics.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>[]? predicates = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByPrimaryKey(object primaryKey, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByPrimaryKey(object primaryKey, CancellationToken cancellationToken);
        Task<TEntity?> GetByPrimaryKeys(object[] primaryKeys, CancellationToken cancellationToken);
        Task<TEntity?> GetByPrimaryKeys(object[] primaryKeys, string[] primaryKeyNames, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>[]? predicates = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>[] predicates, CancellationToken cancellationToken);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}

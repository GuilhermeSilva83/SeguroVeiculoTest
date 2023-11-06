
using SeguroVeiculo.Seedwork.Domain.Specification;

namespace SeguroVeiculo.Seedwork.Domain
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
    {
        void Save(TEntity entity);
        void DeleteById(TId id);

        Task<List<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<bool> ExistAsync(TId id);

        IEnumerable<TEntity> AllMatching<KProperty>(ISpecification<TEntity> specification, int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        Task<IEnumerable<TEntity>> AllMatchingAsync<KProperty>(ISpecification<TEntity> specification, int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        Task<IEnumerable<TEntity>> GetPagedAsync<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> GetFilteredAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter);
    }
}




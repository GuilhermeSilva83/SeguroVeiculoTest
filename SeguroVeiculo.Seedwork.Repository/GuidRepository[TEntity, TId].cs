using SeguroVeiculo.Seedwork.Domain;


namespace SeguroVeiculo.Seedwork.Repository
{
    public class GuidRepository<TEntity> : GenericRepository<TEntity, Guid>, IGuidRepository<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        public GuidRepository(IUnitOfWork ct) : base(ct)
        {
        }
    }
}

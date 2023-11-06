using SeguroVeiculo.Seedwork.Domain;


namespace SeguroVeiculo.Seedwork.Repository
{
    public class Int32Repository<TEntity> : GenericRepository<TEntity, Int32>, IInt32Repository<TEntity>
       where TEntity : class, IEntity<int>
    {
        public Int32Repository(IUnitOfWork ct) : base(ct)
        {
        }

    }
}

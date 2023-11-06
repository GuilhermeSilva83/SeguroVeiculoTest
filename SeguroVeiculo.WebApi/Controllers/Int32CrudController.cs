using AutoMapper;

using SeguroVeiculo.Seedwork.Domain;


namespace SeguroVeiculo.Seedwork.Api.Controllers
{
    public class Int32CrudController<TRepository, TEntity, TDto> : CrudController<int, IRepository<TEntity, int>, TEntity, TDto>
        where TRepository : class, IRepository<TEntity, int>
        where TEntity : class
        where TDto : class

    {

        public Int32CrudController(IUnitOfWork uow, TRepository rep, IMapper mapper) : base(uow, rep, mapper)
        {
               
        }
    }
}

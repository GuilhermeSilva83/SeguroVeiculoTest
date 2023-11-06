using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SeguroVeiculo.CrossCutting;
using SeguroVeiculo.Seedwork.Domain;

namespace SeguroVeiculo.Seedwork.Api.Controllers
{
    public abstract class CrudController<TType, TRepository, TEntity, TDto> : ControllerBase
        where TType : struct
        where TRepository : class, IRepository<TEntity, TType>
        where TEntity : class
        where TDto : class
    {
        protected IMapper mapper;
        protected IUnitOfWork unitOfWork;
        protected TRepository repository;

        public CrudController(IUnitOfWork uow, TRepository rep, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = uow;
            this.repository = rep;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TDto>> List()
        {
            var result = await repository.ListAsync();
            return mapper.Map<IEnumerable<TDto>>(result);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> Get(TType id)
        {
            var result = await this.repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return mapper.Map<TDto>(result);
        }

        [HttpPost]
        [HttpPut]
        public virtual async Task<ActionResult<OperationResult>> Save([FromBody] TDto value)
        {
            var e = mapper.Map<TEntity>(value);
            repository.Save(e);
            await unitOfWork.CommitAsync();
            return OperationResult.Ok(mapper.Map<TDto>(e));
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<OperationResult>> Delete(TType id)
        {
            repository.DeleteById(id);
            await unitOfWork.CommitAsync();
            return OperationResult.Ok();
        }


        protected virtual ActionResult<OperationResult> Handle(OperationResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        protected virtual ActionResult<OperationResult<TData>> Handle<TData>(OperationResult<TData> result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}

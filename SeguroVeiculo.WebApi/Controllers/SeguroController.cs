using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SeguroVeiculo.CrossCutting;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Services;
using SeguroVeiculo.Infra.Repository;
using SeguroVeiculo.Seedwork.Api.Controllers;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.WebApi.Dto;

namespace SeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : Int32CrudController<ISeguroRepository, Seguro, AdicionarSeguroDto>
    {
        private readonly ICalculoValorSeguro calculoValorSeguro;

        public SeguroController(IUnitOfWork uow, ISeguroRepository rep, IMapper mapper, ICalculoValorSeguro calculoValorSeguro) : base(uow, rep, mapper)
        {
            this.calculoValorSeguro = calculoValorSeguro;
        }

        [NonAction]
        public override Task<ActionResult<OperationResult>> Save([FromBody] AdicionarSeguroDto value)
        {
            return base.Save(value);
        }


        [HttpPost("cotar")]
        public async Task<ActionResult<OperationResult>> AdicionarSeguro(AdicionarSeguroDto dto)
        {
            var seguro = mapper.Map<Seguro>(dto);
            var resultado = calculoValorSeguro.CalcularSeguro(seguro.Veiculo.Valor);
            seguro.Valor = resultado.PremioComercial;
            
            repository.Save(seguro);
            await unitOfWork.CommitAsync();

            return Ok(mapper.Map<SeguroDto>(seguro));
        }
    }
}

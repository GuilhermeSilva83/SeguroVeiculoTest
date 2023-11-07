using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using SeguroVeiculo.CrossCutting;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Services;
using SeguroVeiculo.Infra.Repository;
using SeguroVeiculo.Seedwork.Api.Controllers;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.WebApi.Dto;

using System.Collections.Generic;
using System.Linq.Expressions;

namespace SeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : Int32CrudController<ISeguroRepository, Seguro, AdicionarSeguroDto>
    {
        private readonly ICalculoValorSeguroService calculoValorSeguro;

        public SeguroController(IUnitOfWork uow, ISeguroRepository rep, IMapper mapper, ICalculoValorSeguroService calculoValorSeguro) : base(uow, rep, mapper)
        {
            this.calculoValorSeguro = calculoValorSeguro;
        }

        [NonAction]
        public override Task<ActionResult<OperationResult>> Save([FromBody] AdicionarSeguroDto value)
        {
            return base.Save(value);
        }

        [NonAction]
        public override Task<IEnumerable<AdicionarSeguroDto>> List()
        {
            return base.List();
        }

        [NonAction]
        public override Task<ActionResult<AdicionarSeguroDto>> Get(int id)
        {
            return base.Get(id);
        }


        [HttpGet("{id}")]
        public async Task<SeguroDto> GetById(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return mapper.Map<SeguroDto>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<SeguroDto>> Listar([FromQuery] FiltrarSeguroDto dto)
        {
            var result = await repository.GetFilteredAsync(
                a => (
                   (a.Id == dto.Id | dto.Id.HasValue == false)
                & (a.Segurado.CPF == dto.Cpf | string.IsNullOrWhiteSpace(dto.Cpf))
                & (a.Segurado.Nome.Contains(dto.Nome) | string.IsNullOrWhiteSpace(dto.Nome))

                ));

            return mapper.Map<IEnumerable<SeguroDto>> (result);
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

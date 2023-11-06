using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.Infra.Repository;
using SeguroVeiculo.Seedwork.Api.Controllers;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.WebApi.Dto;

using System.ComponentModel;

namespace SeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : Int32CrudController<VeiculoRepository, Veiculo, VeiculoDto>
    {
        public VeiculoController(IUnitOfWork uow, VeiculoRepository rep, IMapper mapper) : base(uow, rep, mapper)
        {
        }
    }
}

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SeguroVeiculo.CrossCutting;
using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Seedwork.Api.Controllers;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.WebApi.Dto;

namespace SeguroVeiculo.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeguradoController : Int32CrudController<ISeguradoRepository, Segurado, SeguradoDto> 
    {
        public SeguradoController(IUnitOfWork uow, ISeguradoRepository rep, IMapper mapper) : base(uow, rep, mapper)
        {

        }

       
    }
}

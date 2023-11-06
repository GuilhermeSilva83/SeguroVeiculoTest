using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.WebApi.Dto;

namespace SeguroVeiculo.WebApi.Map
{
    public class EntityToDtoProfile : AutoMapper.Profile
    {
        public EntityToDtoProfile()
        {
            this.CreateMap<Seguro, SeguroDto>().ReverseMap();
            this.CreateMap<Segurado, SeguradoDto>().ReverseMap();
            this.CreateMap<Veiculo, VeiculoDto>().ReverseMap();
        }
    }
}

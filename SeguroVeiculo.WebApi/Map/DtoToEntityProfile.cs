using AutoMapper;

using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.WebApi.Dto;

using System.Reflection;

namespace SeguroVeiculo.WebApi.Map
{
    public class DtoToEntityProfile : AutoMapper.Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<AdicionarSeguroDto, Seguro>().ConvertUsing(new AdicionarSeguroDtoParaSeguro());
        }
    }


    public class AdicionarSeguroDtoParaSeguro : ITypeConverter<AdicionarSeguroDto, Seguro>
    {
        public Seguro Convert(AdicionarSeguroDto source, Seguro destination, ResolutionContext context)
        {
            return new Seguro()
            {
                Segurado = new Segurado()
                {
                    CPF = source.CPF,
                    DataNascimento = source.DataNascimento,
                    Nome = source.Nome
                },
                Veiculo = new Veiculo()
                {
                    Marca = source.Marca,
                    Modelo = source.Modelo,
                    Placa = source.Placa,
                    Valor = source.Valor
                }
            };
        }
    }
}

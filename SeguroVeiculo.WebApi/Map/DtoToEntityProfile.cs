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
            //CreateMap<AdicionarSeguroDto, Seguro>().ConvertUsing( new AdicionarSeguroDtoParaSeguro());

            CreateMap<AdicionarSeguroDto, Seguro>().ConvertUsing((source, seguro) =>
            {
                seguro = new Seguro();
                seguro.Segurado = new Segurado()
                {
                    CPF = source.CPF,
                    DataNascimento = source.DataNascimento,
                    Nome = source.Nome
                };
                seguro.Veiculo = new Veiculo()
                {
                    Marca = source.Marca,
                    Modelo = source.Modelo,
                    Placa = source.Placa,
                    Valor = source.Valor
                };

                return seguro;
            });
        }
    }
}

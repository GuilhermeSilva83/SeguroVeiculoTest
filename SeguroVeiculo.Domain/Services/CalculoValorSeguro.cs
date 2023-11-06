using SeguroVeiculo.Domain.Aggs.SeguroAgg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Services
{
    public class CalculoValorSeguro : ICalculoValorSeguro
    {
        public const decimal MergemSeguranca = 3;
        public const decimal Lucro = 5;

        public ResultadoCalculo CalcularSeguro(decimal valorVeiculo)
        {

            var taxaRisco = (valorVeiculo * 5) / (2 * valorVeiculo);
            var premioRisco = taxaRisco * valorVeiculo;
            var premioPuro = premioRisco * (1 + CalculoValorSeguro.MergemSeguranca);
            var premioComercial = Lucro * premioPuro; // Valor do Seguro


            return new ResultadoCalculo()
            {
                TaxaRisco = taxaRisco,
                PremioRisco = premioRisco,
                PremioPuro = premioPuro,
                PremioComercial = premioComercial
            };
        }
    }
}

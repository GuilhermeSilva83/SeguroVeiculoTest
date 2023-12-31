﻿using SeguroVeiculo.Domain.Aggs.SeguroAgg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Services
{
    public class CalculoValorSeguroService : ICalculoValorSeguroService
    {
        public const decimal MergemSeguranca = 1.03m;
        public const decimal Lucro = 1.05m;

        public ResultadoCalculo CalcularSeguro(decimal valorVeiculo)
        {

            var taxaRisco = (valorVeiculo * 5) / (2 * valorVeiculo);
            var premioRisco = (taxaRisco / 100) * valorVeiculo;
            var premioPuro = premioRisco * MergemSeguranca;
            var premioComercial = Lucro * premioPuro; // Valor do Seguro


            return new ResultadoCalculo()
            {
                TaxaRisco = taxaRisco,
                PremioRisco = premioRisco,
                PremioPuro = premioPuro,
                PremioComercial = Math.Round(premioComercial, 2, MidpointRounding.ToZero)
            };
        }
    }
}

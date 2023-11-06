using SeguroVeiculo.Domain.Aggs.SeguroAgg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Services
{
    public interface ICalculoValorSeguro
    {
        ResultadoCalculo CalcularSeguro(decimal valorVeiculo);
    }
}

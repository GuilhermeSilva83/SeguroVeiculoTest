using SeguroVeiculo.Seedwork.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Aggs.VeiculoAgg
{
    public class Veiculo : Int32Entity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public decimal Valor { get; set; }
    }
}

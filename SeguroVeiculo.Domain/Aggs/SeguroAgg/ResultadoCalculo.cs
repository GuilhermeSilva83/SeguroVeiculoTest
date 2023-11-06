using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Aggs.SeguroAgg
{
    public class ResultadoCalculo
    {
        public decimal TaxaRisco { get; internal set; }
        public decimal PremioRisco { get; internal set; }
        public decimal PremioPuro { get; internal set; }
        public decimal PremioComercial { get; internal set; }
    }
}

using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.Seedwork.Domain;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Aggs.SeguroAgg
{
    public class Seguro : Int32Entity
    {
        public decimal Valor { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FimVigencia { get; set; }

        [ForeignKey(nameof(SeguradoId))]
        public int SeguradoId { get; set; }
        public Segurado Segurado { get; set; }


        [ForeignKey(nameof(VeiculoId))]
        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}

using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Seedwork.Domain;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SeguroVeiculo.Domain.Aggs.SeguradoAgg
{
    public class Segurado : Int32Entity
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<Seguro> Seguros { get; set; } = new();
    }
}

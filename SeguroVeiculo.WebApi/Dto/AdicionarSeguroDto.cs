using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;

using System.ComponentModel.DataAnnotations;

namespace SeguroVeiculo.WebApi.Dto
{
    public class AdicionarSeguroDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public decimal Valor { get; set; }
    }
}

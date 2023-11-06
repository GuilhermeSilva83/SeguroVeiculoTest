using System.ComponentModel.DataAnnotations;

namespace SeguroVeiculo.WebApi.Dto
{
    public class SeguradoDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

    }
}

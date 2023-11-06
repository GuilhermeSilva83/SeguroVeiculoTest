using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.WebApi.Dto
{
    public class SeguroDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public SeguradoDto Segurado { get; set; }
        public VeiculoDto Veiculo { get; set; }
    }
}

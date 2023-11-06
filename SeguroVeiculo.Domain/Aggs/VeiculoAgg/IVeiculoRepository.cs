using SeguroVeiculo.Seedwork.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Aggs.VeiculoAgg
{
    public interface IVeiculoRepository : IInt32Repository<Veiculo>
    {
    }
}

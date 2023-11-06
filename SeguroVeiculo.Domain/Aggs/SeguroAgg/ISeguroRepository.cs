using SeguroVeiculo.Seedwork.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Domain.Aggs.SeguroAgg
{
    public interface ISeguroRepository : IInt32Repository<Seguro>
    {
    }
}

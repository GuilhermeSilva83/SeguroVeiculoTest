using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Infra.Repository
{
    public class SeguradoRepository : Int32Repository<Segurado>, ISeguradoRepository
    {
        public SeguradoRepository(IUnitOfWork ct) : base(ct)
        {
        }
    }
}

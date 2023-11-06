using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Infra.Repository
{
    public class SeguroRepository : Int32Repository<Seguro>, ISeguroRepository
    {
        public SeguroRepository(IUnitOfWork ct) : base(ct)
        {
        }
    }
}

using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Infra.Repository
{
    public class VeiculoRepository : Int32Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(IUnitOfWork ct) : base(ct)
        {
        }
    }
}

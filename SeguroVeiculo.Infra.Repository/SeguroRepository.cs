using Microsoft.EntityFrameworkCore;

using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Infra.Repository
{
    public class SeguroRepository : Int32Repository<Seguro>, ISeguroRepository
    {
        public SeguroRepository(IUnitOfWork ct) : base(ct)
        {
        }

        protected override IQueryable<Seguro> Include(IQueryable<Seguro> set)
        {
            return set.Include(a => a.Segurado).Include(i => i.Veiculo);
        }

        public override Task<IEnumerable<Seguro>> GetFilteredAsync(Expression<Func<Seguro, bool>> filter)
        {
            return base.GetFilteredAsync(filter);
        }
    }
}

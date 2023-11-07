using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SeguroVeiculo.Domain.Aggs.SeguradoAgg;
using SeguroVeiculo.Domain.Aggs.SeguroAgg;
using SeguroVeiculo.Domain.Aggs.VeiculoAgg;
using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Repository;

namespace SeguroVeiculo.Infra.Repository
{
    public class MainContextUnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public virtual DbSet<Segurado> Segurado { get; set; }
        public virtual DbSet<Seguro> Seguro { get; set; }

        public virtual DbSet<Veiculo> Veiculo { get; set; }



        public MainContextUnitOfWork(DbContextOptions ct) : base(ct)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

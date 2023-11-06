using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using SeguroVeiculo.Seedwork.Domain;

namespace SeguroVeiculo.Seedwork.Repository
{
    public class BaseUnitOfWork : DbContext, IUnitOfWork
    {
        private IDbContextTransaction Transaction;

        public BaseUnitOfWork(DbContextOptions ct)  : base(ct) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual async Task CommitAsync()
        {

            await SaveChangesAsync();
            if (this.Transaction != null)
            {
               await this.Transaction.CommitAsync();
            }
        }

        public virtual async Task BeginTransaction()
        {
            this.Transaction = await Database.BeginTransactionAsync();
        }
    }
}

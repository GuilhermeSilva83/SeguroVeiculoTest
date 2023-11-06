using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SeguroVeiculo.Seedwork.Domain
{
    public interface IUnitOfWork
    {
        Task  BeginTransaction();
        Task CommitAsync();
    }
}

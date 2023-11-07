using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


using SeguroVeiculo.Seedwork.Domain;
using SeguroVeiculo.Seedwork.Domain.Specification;

namespace SeguroVeiculo.Seedwork.Repository
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId>
      where TEntity : class, IEntity<TId>
      where TId : struct
    {
        private readonly BaseUnitOfWork ct;
        public GenericRepository(IUnitOfWork ct)
        {
            this.ct = ct as BaseUnitOfWork;
        }

        public virtual void DeleteById(TId id)
        {
            var set = GetSet()
                        .Where(w => w.Id.Equals(id))
                        .ExecuteDelete();
        }

        public virtual void Save(TEntity entity)
        {
            if (entity.IsTransient())
            {
                entity.CreateDate = DateTime.Now;
                GetSet().Add(entity);
            }
            else
            {
                entity.UpdateDate = DateTime.Now;
                GetSet().Update(entity);
            }
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> set)
        {
            return set;
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            return await Include(from e in GetSet()
                          where e.Id.Equals(id)
                          select e)
                          .FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> ListAsync()
        {
            return await (from e in GetSet()
                   select e).ToListAsync();
        }

        protected virtual DbSet<TEntity> GetSet()
        {
            return ct.Set<TEntity>();
        }

        public async virtual Task<bool> ExistAsync(TId id)
        {
            return await (from e in GetSet()
                         where e.Id.Equals(id)
                         select e).AnyAsync();
        }


        public virtual IEnumerable<TEntity> AllMatching<KProperty>(ISpecification<TEntity> specification, int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.Where(specification.SatisfiedBy())
                          .OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.Where(specification.SatisfiedBy())
                          .OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> AllMatchingAsync<KProperty>(ISpecification<TEntity> specification, int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return await set.Where(specification.SatisfiedBy())
                          .OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
            else
            {
                return await set.Where(specification.SatisfiedBy())
                          .OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
        }

        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedAsync<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return await set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
            else
            {
                return await set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
        }

        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetFilteredAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return await GetSet().Where(filter).ToListAsync();
        }

      
    }
}

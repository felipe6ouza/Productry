using Microsoft.EntityFrameworkCore;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Productry.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        protected readonly ProductryDbContext Db;
        protected readonly DbSet<T> DbSet;
        public Repository(ProductryDbContext productryDbContext)
        {
            Db = productryDbContext;
            DbSet = productryDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<bool> Adicionar(T entity)
        {
            DbSet.Add(entity);
            var added =  await SaveChanges();

            return added > 1;
        }

        public async Task <bool> Atualizar(T entity)
        {
            DbSet.Update(entity);
            var modified = await SaveChanges();

            return modified > 1;
        }

        public virtual async Task<T> ObterPorId(int id)
        {
           return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remover(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}

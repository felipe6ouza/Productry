using Microsoft.EntityFrameworkCore;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Productry.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly ProductryDbContext Db;
        protected readonly DbSet<T> DbSet;
        public Repository(ProductryDbContext productryDbContext)
        {
            Db = productryDbContext;
            DbSet = productryDbContext.Set<T>();
        }


        public async Task Adicionar(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

      

        public async Task<T> ObterPorId(Guid id)
        {
           return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
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

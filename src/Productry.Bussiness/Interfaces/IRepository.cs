using Productry.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface IRepository <T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(Guid id);
        Task<int> SaveChanges();
    }
}

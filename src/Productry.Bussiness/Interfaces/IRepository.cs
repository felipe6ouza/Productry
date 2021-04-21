using Productry.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface IRepository <T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(int id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(int id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}

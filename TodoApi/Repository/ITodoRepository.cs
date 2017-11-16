using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public interface ITodoRepository : IDisposable
    {
        IQueryable<Todo> GetAll();
        void Add(Todo todo);
        void Remove(int id);
        void Update(int id, Todo todo);
        Todo Get(int id);
    }
}

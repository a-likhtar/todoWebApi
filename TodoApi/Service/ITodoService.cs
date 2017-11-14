using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoService : IDisposable
    {
        IQueryable<Todo> GetAll();
        Todo Get(int id);
        void Add(Todo todo);
        void Remove(int id);
        void Update(int id, Todo todo);
    }
}

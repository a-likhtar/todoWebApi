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
        IEnumerable<Todo> GetAll();
        int Add(Todo todo);
        int Remove(int id);
        void Update(int id, Todo todo);
        Todo Get(int id);
    }
}

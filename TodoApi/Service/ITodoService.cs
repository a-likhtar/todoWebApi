using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo Get(int id);
        int Add(Todo todo);
        int Remove(int id);
        void Update(int id, Todo todo);
    }
}

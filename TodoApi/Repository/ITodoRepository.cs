using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public interface ITodoRepository : IRepository<Todo>, IDisposable
    {

    }
}

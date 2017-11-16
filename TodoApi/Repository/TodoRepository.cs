using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoApiContext _db;

        public TodoRepository(TodoApiContext db)
        {
            _db = db;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _db.Todoes;
        }
        
        public Todo Get(int id)
        {
            return _db.Todoes.Find(id);
        }

        public int Add(Todo item)
        {
            _db.Todoes.Add(item);
            _db.SaveChanges();
            return item.Id;
        }

        public int Remove(int id)
        {
            Todo todo = _db.Todoes.Find(id);
            _db.Todoes.Remove(todo);
            _db.SaveChanges();
            return id;
        }

        public void Update(int id, Todo item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
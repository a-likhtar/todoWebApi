using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Todo> GetAll()
        {
            return _repository.GetAll();
        }

        public Todo Get(int id)
        {
            return _repository.Get(id);
        }

        public void Add(Todo todo)
        {
            _repository.Add(todo);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(int id, Todo todo)
        {
            _repository.Update(id, todo);
        }


        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
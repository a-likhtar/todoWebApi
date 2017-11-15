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
            if (id < 0)
            {
                throw new ArgumentException();
            }
            var item = _repository.Get(id);
            if (item == null) throw  new IndexOutOfRangeException();
            return item;
        }

        public void Add(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException();
            }

            if (todo.Id < 0 || todo.UserId < 0 || todo.Title.Length > 50 || todo.Project.Length > 50)
            {
                throw new ArgumentException();
            }
            try
            {
                _repository.Add(todo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }

            try
            {
                _repository.Remove(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int id, Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException();
            }

            if (todo.Id < 0 || todo.UserId < 0 || todo.Title.Length > 50 || todo.Project.Length > 50)
            {
                throw new ArgumentException();
            }
            try
            {
                _repository.Update(id, todo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
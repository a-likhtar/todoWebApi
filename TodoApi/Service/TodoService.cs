using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IEnumerable<Todo> GetAll()
        {
            return _repository.GetAll();
        }

        public Todo Get(int id)
        {
            return _repository.Get(id);
        }

        public int Add(Todo todo)
        {
            try
            {
                if (Utils.Validator.Validate(todo))
                {
                    int id = _repository.Add(todo);
                    return id;
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Remove(int id)
        {
            try
            {
                int justRemovedId = _repository.Remove(id);
                return justRemovedId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int id, Todo todo)
        {
            try
            {
                if (Utils.Validator.Validate(todo))
                {
                   _repository.Update(id, todo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
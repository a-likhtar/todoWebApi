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
            try
            {
                if(Utils.Validator.Validate(todo)) { 
                    _repository.Add(todo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(int id)
        {
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TodoApi.Models;
using TodoApi.Repository;
using TodoApi.Service;

namespace TodoApi.Controllers
{
    public class TodoesController : ApiController
    {
        private readonly ITodoService _service;

        public TodoesController(ITodoService service)
        {
            _service = service;
        }

        // GET: api/Todoes
        public IEnumerable<Todo> GetTodoes()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Todoes/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
            Todo todo;
            try
            {
                todo = _service.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(todo);
        }

        // PUT: api/Todoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, Todo todo)
        {
            try
            {
                _service.Update(id, todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todoes
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo(Todo todo)
        {
            int justAddedId;
            try
            {
                justAddedId =_service.Add(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("DefaultApi", new { id = justAddedId }, todo);
        }

        // DELETE: api/Todoes/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id)
        {
            try
            {
                int justRemovedId = _service.Remove(id);
                return Ok(justRemovedId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
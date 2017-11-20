using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TodoApi.Models;
using TodoApi.Service;
using TodoApi.Service.Utils;

namespace TodoApi.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        // GET: api/Todoes
        public IHttpActionResult GetTodoes()
        {
            var todos = _service.GetAll();
            if (todos != null)
                return Ok(todos);
            return NotFound();
        }

        // GET: api/Todoes/5
        // Todo: handle only necessary type of exceptions
        [TodoException(ExceptionType = typeof(Exception),
            StatusCode = HttpStatusCode.BadRequest, Message = "Error")]
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
            var todo = _service.Get(id);
            return Ok(todo);
        }

        // PUT: api/Todoes/5
        [TodoException(ExceptionType = typeof(Exception),
            StatusCode = HttpStatusCode.BadRequest, Message = "Error")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, Todo todo)
        {
            _service.Update(id, todo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todoes
        [TodoException(ExceptionType = typeof(Exception),
            StatusCode = HttpStatusCode.BadRequest, Message = "Error")]
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo(Todo todo)
        {
            var justAddedId = _service.Add(todo);
            return CreatedAtRoute("DefaultApi", new {id = justAddedId}, todo);
        }

        // DELETE: api/Todoes/5
        [TodoException(ExceptionType = typeof(Exception),
            StatusCode = HttpStatusCode.BadRequest, Message = "Error")]
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id)
        {
            var justRemovedId = _service.Remove(id);
            return Ok(justRemovedId);
        }
    }
}
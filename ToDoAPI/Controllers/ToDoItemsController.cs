using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoService toDoService;

        public ToDoItemsController(ToDoService service)
        {
            toDoService = service;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public ActionResult<List<ToDoItem>> GetTodoItems()
        {
            List<ToDoItem> items = toDoService.Get();
            return items;
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItem = toDoService.Get(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]

        public ActionResult<ToDoItem> Update(long id, ToDoItem item)
        {
            var itemFound = toDoService.Get(id);
            if (item == null)
                return NotFound();
            toDoService.Update(itemFound);

            return NoContent();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public ActionResult<ToDoItem> PostToDoItem([FromBody] ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            toDoService.Create(toDoItem);

            return CreatedAtAction(nameof(GetToDoItem), new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public ActionResult<ToDoItem> DeleteToDoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItem = toDoService.Get(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            toDoService.Delete(id);

            return Ok(toDoItem);
        }
    }
}
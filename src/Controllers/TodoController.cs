using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using src;

namespace TodoApi.Controllers
{

    [ApiController]

    [Route("[controller]")]

    public class TodoController : ControllerBase
    {


        private IRepo<TodoItem> _repo;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger, IRepo<TodoItem> repo)

        {
            _logger = logger;

            _repo = repo;
        }

        [HttpGet(Name = "GetTodos")]
        public async Task<ActionResult<List<TodoItem>>> Get()
        {
            var todos = await _repo.Get();
            return todos;
        }

        [HttpPost(Name = "AddTodo")]
        public async Task Post(TodoItem todo)
        {

            await this._repo.Save(todo);

        }
    }
}

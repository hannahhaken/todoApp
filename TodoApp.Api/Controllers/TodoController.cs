using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using TodoApp.Core.Todo;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;

        public TodoController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            const string sql = "SELECT * FROM TodoItem WHERE DeletedAt IS NULL";
            var todos = await _dbConnection.QueryAsync<TodoItem>(sql);
            return Ok(todos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(string id)
        {
            const string sql = "SELECT * FROM TodoItem WHERE Id = @Id  AND DeletedAt IS NULL";
            var todo = await _dbConnection.QueryFirstOrDefaultAsync<TodoItem>(sql, new { Id = id });

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem newTodo)
        {
            newTodo.Id = Guid.NewGuid().ToString();
            newTodo.CreatedAt = DateTime.Now;
            newTodo.UpdatedAt = DateTime.Now;
            newTodo.Status = TodoStatus.Due;

            const string sql = """
                               INSERT INTO TodoItems (Id, Title, Description, Status, CreatedAt, UpdatedAt, DueAt, CreatedById, AssignedToId) 
                               VALUES (@Id, @Title, @Description, @Status, @CreatedAt, @UpdatedAt, @DueAt, @CreatedById, @AssignedToId)
                               """;

            await _dbConnection.ExecuteAsync(sql, newTodo);

            return CreatedAtAction(nameof(GetTodoById), new { id = newTodo.Id }, newTodo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(string id, [FromBody] TodoItem updatedTodo)
        {
            const string sql =
                "UPDATE TodoItems SET Title = @Title, Description = @Description, Status = @Status, DueAt = @DueAt, UpdatedAt = @UpdatedAt, AssignedToId = @AssignedToId WHERE Id = @Id AND DeletedAt IS NULL";

            updatedTodo.UpdatedAt = DateTime.UtcNow;

            var rowsAffected = await _dbConnection.ExecuteAsync(sql,
                new
                {
                    updatedTodo.Title, updatedTodo.Description, updatedTodo.Status, updatedTodo.UpdatedAt,
                    updatedTodo.DueAt, updatedTodo.AssignedToId, Id = id
                }
            );

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            const string sql =
                " UPDATE TodoItems SET DeletedAt = @DeletedAt, Status = @Status, WHERE Id = @Id AND DeletedAt IS NULL ";

            var rowsAffected = await _dbConnection.ExecuteAsync(sql,
                new { DeletedAt = DateTime.UtcNow, Status = TodoStatus.Deleted, Id = id });

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
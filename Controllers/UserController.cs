using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ApiContext _context;
    public UserController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/user
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = _context.Users;
        return await users.ToListAsync();
    }

    // GET: api/user/1
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user == null)
            return NotFound();
        return user;
    }

    // // POST: api/todo
    // [HttpPost]
    // public async Task<ActionResult<Todo>> PostTodo(Todo todo)
    // {
    //         _context.Todos.Add(todo);
    // await _context.SaveChangesAsync();
    // return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    // }

    // // PUT: api/todo/2
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutTodo(int id, Todo todo)
    // {
    // if (id != todo.Id)
    // return BadRequest();
    //         _context.Entry(todo).State = EntityState.Modified;
    // try
    // {
    // await _context.SaveChangesAsync();
    // }
    // catch (DbUpdateConcurrencyException)
    // {
    // if (!_context.Todos.Any(m => m.Id == id))
    // return NotFound();
    // else
    // throw;
    // }
    // return NoContent();
    // }

    // // DELETE: api/todo/2
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteTodoItem(int id)
    // {
    // var todo = await _context.Todos.FindAsync(id);
    // if (todo == null)
    // return NotFound();
    //         _context.Todos.Remove(todo);
    // await _context.SaveChangesAsync();
    // return NoContent();
    // }
}
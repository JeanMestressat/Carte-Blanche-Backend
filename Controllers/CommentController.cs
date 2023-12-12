using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

[ApiController]
[Route("api/comment")]
public class CommentController : ControllerBase
{
    private readonly ApiContext _context;
    public CommentController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/comment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> Getcomments()
    {
        var comments = _context.Comments;
        return await comments.ToListAsync();
    }

    // GET: api/comment/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> Getcomment(int id)
    {
        var comment = await _context.Comments.SingleOrDefaultAsync(c => c.Id == id);
        if (comment == null)
            return NotFound();
        return comment;
    }

    // GET: api/comment/game/1
    [HttpGet("game/{id}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetcommentGame(int id)
    {
        var comments = await _context.Comments.Where(c => c.Id_Game == id).ToListAsync();
        if (comments == null || !comments.Any())
            return NotFound();

        return comments;
    }

    // POST: api/comment
    [HttpPost]
    public async Task<ActionResult<Comment>> Postcomment(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Getcomment), new { id = comment.Id }, comment);
    }

    // PUT: api/comment/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Putcomment(int id, Comment comment)
    {
        if (id != comment.Id)
            return BadRequest();
        _context.Entry(comment).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comments.Any(c => c.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/comment/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletecommentItem(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
            return NotFound();
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
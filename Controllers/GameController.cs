using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/game")]
public class GameController : ControllerBase
{
    private readonly ApiContext _context;
    public GameController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/game
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        var games = _context.Games;
        return await games.ToListAsync();
    }

    // GET: api/game/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games.SingleOrDefaultAsync(g => g.Id == id);
        if (game == null)
            return NotFound();
        return game;
    }

    // POST: api/game
    [HttpPost]
    public async Task<ActionResult<Game>> PostGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
    }

    // PUT: api/game/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, Game game)
    {
        if (id != game.Id)
            return BadRequest();
        _context.Entry(game).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Games.Any(u => u.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/game/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGameItem(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
            return NotFound();
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballRestService.Data;
using FootballRestService.Models;

namespace FootballRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly FootballRestServiceContext _context;

        public PlayersController(FootballRestServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.Include(p => p.Team).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.Include(p => p.Team)
                                               .FirstOrDefaultAsync(p => p.PlayerID == id);
            if (player == null) return NotFound();
            return player;
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerID }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.PlayerID) return BadRequest();

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }
    }
}
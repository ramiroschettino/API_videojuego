using API_videojuego.Data;
using API_videojuego.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_videojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {

        private readonly AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(Player player)
        {
            if (player == null)
            {
                return BadRequest();
            }
            else {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                return Ok(player.Id);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id) 
        { 
            var player = await _context.Players.FindAsync(id);
            return Ok(player);
        }

    }
}

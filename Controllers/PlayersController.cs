using API_videojuego.Data;
using API_videojuego.Features.Players.CreatePlayer;
using API_videojuego.Features.Players.GetPlayerById;
using API_videojuego.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_videojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {

        private readonly AppDbContext _context;
        private readonly ISender _sender;

        public PlayersController(AppDbContext context, ISender sender)
        {
            _context = context;
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {

            var playerId = await _sender.Send(command);
            return Ok(playerId);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id) 
        {
            var player = await _sender.Send(new GetPlayerByIdQuery(id));

            if (player is null)
                return NotFound();

            return Ok(player);
        }

    }
}

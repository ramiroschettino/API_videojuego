using API_videojuego.Data;
using API_videojuego.Models;
using MediatR;

namespace API_videojuego.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly AppDbContext _context;

        public CreatePlayerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name = request.Name , Level = request.Level };
            
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player.Id;

        }
    }
}

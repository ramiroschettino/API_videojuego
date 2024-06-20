using MediatR;

namespace API_videojuego.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Name, int Level) : IRequest<int>;
}

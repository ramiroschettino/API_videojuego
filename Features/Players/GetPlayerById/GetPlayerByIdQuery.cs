using API_videojuego.Models;
using MediatR;

namespace API_videojuego.Features.Players.GetPlayerById
{
    public record GetPlayerByIdQuery(int Id) : IRequest<Player?>;
}

using API_videojuego.Models;
using Microsoft.EntityFrameworkCore;

namespace API_videojuego.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}

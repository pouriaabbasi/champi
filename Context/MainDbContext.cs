using champi.Domain.Entity;
using champi.Domain.Map;
using Microsoft.EntityFrameworkCore;

namespace champi.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base() { }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        public DbSet<GameType> GameTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameTypeMap).Assembly);
            
        }
    }
}
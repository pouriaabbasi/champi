using champi.Domain.Entity.Competition;
using champi.Domain.Entity.Security;
using champi.Domain.Map.Competition;
using champi.Domain.Map.Security;
using Microsoft.EntityFrameworkCore;

namespace champi.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base() { }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        //Competition
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionStep> CompetitionSteps { get; set; }
        public DbSet<CompetitionTeam> CompetitionTeams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueMatch> LeagueMatches { get; set; }
        public DbSet<LeagueResult> LeagueResults { get; set; }
        public DbSet<LeagueTeam> LeagueTeams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameTypeMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }
    }
}
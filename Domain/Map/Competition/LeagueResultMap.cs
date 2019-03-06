using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class LeagueResultMap : IEntityTypeConfiguration<LeagueResult>
    {
        public void Configure(EntityTypeBuilder<LeagueResult> builder)
        {
            builder
                .HasOne(x => x.LeagueTeam)
                .WithMany(x => x.LeagueResults)
                .HasForeignKey(x => x.LeagueTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.LeagueResults)
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("LeagueResult", "Competition");
        }
    }
}
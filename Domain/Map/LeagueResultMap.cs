using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class LeagueResultMap : IEntityTypeConfiguration<LeagueResult>
    {
        public void Configure(EntityTypeBuilder<LeagueResult> builder)
        {
            builder
                .HasOne(x => x.LeagueTeam)
                .WithMany(x => x.LeagueResults)
                .HasForeignKey(x => x.LeagueTeamId);
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.LeagueResults)
                .HasForeignKey(x => x.LeagueId);

            builder
                .ToTable("LeagueResult", "Competition");
        }
    }
}
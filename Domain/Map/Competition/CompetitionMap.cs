using champi.Domain.Entity.Competition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map.Competition
{
    public class CompetitionMap : IEntityTypeConfiguration<champi.Domain.Entity.Competition.Competition>
    {
        public void Configure(EntityTypeBuilder<champi.Domain.Entity.Competition.Competition> builder)
        {
            builder
                .HasOne(x => x.ChampionTeam)
                .WithMany(x => x.ChampionCompetitions)
                .HasForeignKey(x => x.ChampionTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.GameType)
                .WithMany(x => x.Competitions)
                .HasForeignKey(x => x.GameTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Name).HasMaxLength(200);

            builder
                .ToTable("Competition", "Competition");
        }
    }
}
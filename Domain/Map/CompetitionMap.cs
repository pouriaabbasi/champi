using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class CompetitionMap : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder
                .HasOne(x => x.ChampionTeam)
                .WithMany(x => x.ChampionCompetitions)
                .HasForeignKey(x => x.ChampionTeamId);

            builder
                .Property(x => x.Name).HasMaxLength(200);

            builder
                .ToTable("Competition", "Competition");
        }
    }
}
using champi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class CompetitionStepMap : IEntityTypeConfiguration<CompetitionStep>
    {
        public void Configure(EntityTypeBuilder<CompetitionStep> builder)
        {
            builder
                .HasOne(x => x.Competition)
                .WithMany(x => x.CompetitionSteps)
                .HasForeignKey(x => x.CompetitionId);

            builder
                .ToTable("CompetitionStep", "Competition");
        }
    }
}
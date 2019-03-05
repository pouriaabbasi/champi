using champi.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace champi.Domain.Map
{
    public class CompetitionMap : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder
                .Property(x => x.Name).HasMaxLength(200);

            builder
                .ToTable("Competition", "Competition");
        }
    }
}
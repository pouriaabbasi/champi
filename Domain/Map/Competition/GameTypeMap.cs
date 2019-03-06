using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using champi.Domain.Entity.Competition;

namespace champi.Domain.Map.Competition
{
    public class GameTypeMap : IEntityTypeConfiguration<GameType>
    {
        public void Configure(EntityTypeBuilder<GameType> builder)
        {
            builder
                .HasOne(x => x.ParentGameType)
                .WithMany(x => x.ChildGameTypes)
                .HasForeignKey(x => x.ParentGameTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Name).HasMaxLength(100);

            builder
                .ToTable("GameType", "Competition");
        }
    }
}
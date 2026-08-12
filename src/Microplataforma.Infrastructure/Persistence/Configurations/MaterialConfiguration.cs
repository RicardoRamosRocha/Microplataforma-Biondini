using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microplataforma.Domain.Entities;

namespace Microplataforma.Infrastructure.Persistence.Configurations;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.FileUrl)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ThumbnailUrl)
            .HasMaxLength(500);

        builder.HasOne(x => x.Candidate)
            .WithMany(x => x.Materials)
            .HasForeignKey(x => x.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

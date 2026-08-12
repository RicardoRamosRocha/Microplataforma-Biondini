using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microplataforma.Domain.Entities;

namespace Microplataforma.Infrastructure.Persistence.Configurations;

public class SocialLinkConfiguration : IEntityTypeConfiguration<SocialLink>
{
    public void Configure(EntityTypeBuilder<SocialLink> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Platform)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasOne(x => x.Candidate)
            .WithMany(x => x.SocialLinks)
            .HasForeignKey(x => x.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

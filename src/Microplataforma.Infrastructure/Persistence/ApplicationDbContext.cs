using Microsoft.EntityFrameworkCore;
using Microplataforma.Domain.Entities;

namespace Microplataforma.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Candidate> Candidates => Set<Candidate>();

    public DbSet<Content> Contents => Set<Content>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<SocialLink> SocialLinks => Set<SocialLink>();

    public DbSet<Material> Materials => Set<Material>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

using Microsoft.EntityFrameworkCore;
using Microplataforma.Domain.Entities;

namespace Microplataforma.Infrastructure.Persistence;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Candidates.AnyAsync())
            return;

        context.Candidates.AddRange(
            new Candidate
            {
                Name = "Eros Biondini",
                Slug = "eros",
                Office = "Deputado Federal",
                ShortBiography = "Informação oficial, trajetória e atuação parlamentar.",
                Biography = string.Empty,
                IsActive = true
            },
            new Candidate
            {
                Name = "Chiara Biondini",
                Slug = "chiara",
                Office = "Deputada Estadual",
                ShortBiography = "Informação oficial, trajetória e atuação parlamentar.",
                Biography = string.Empty,
                IsActive = true
            });

        await context.SaveChangesAsync();
    }
}

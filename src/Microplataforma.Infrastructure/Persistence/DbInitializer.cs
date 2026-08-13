using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microplataforma.Domain.Entities;
using Microplataforma.Infrastructure.Identity;

namespace Microplataforma.Infrastructure.Persistence;

public static class DbInitializer
{
    public static async Task SeedCandidatesAsync(ApplicationDbContext context)
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
                PhotoUrl = "/images/candidates/eros-biondini.png",
                IsActive = true
            },
            new Candidate
            {
                Name = "Chiara Biondini",
                Slug = "chiara",
                Office = "Deputada Estadual",
                ShortBiography = "Informação oficial, trajetória e atuação parlamentar.",
                Biography = string.Empty,
                PhotoUrl = "/images/candidates/chiara-biondini.png",
                IsActive = true
            });

        await context.SaveChangesAsync();
    }

    public static async Task SeedAdminAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        const string roleName = "Admin";

        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var roleResult = await roleManager.CreateAsync(
                new IdentityRole(roleName));

            if (!roleResult.Succeeded)
                throw new InvalidOperationException(
                    "Não foi possível criar a role Admin.");
        }

        var email = configuration["Admin:Email"];
        var password = configuration["Admin:Password"];

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        var user = await userManager.FindByEmailAsync(email);

        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var userResult = await userManager.CreateAsync(user, password);

            if (!userResult.Succeeded)
            {
                var errors = string.Join(
                    "; ",
                    userResult.Errors.Select(error => error.Description));

                throw new InvalidOperationException(
                    $"Não foi possível criar o usuário administrador: {errors}");
            }
        }

        if (!await userManager.IsInRoleAsync(user, roleName))
        {
            var roleResult = await userManager.AddToRoleAsync(user, roleName);

            if (!roleResult.Succeeded)
                throw new InvalidOperationException(
                    "Não foi possível atribuir a role Admin ao usuário.");
        }
    }
}

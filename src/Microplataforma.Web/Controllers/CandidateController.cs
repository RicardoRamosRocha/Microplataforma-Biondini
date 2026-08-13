using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microplataforma.Domain.Enums;
using Microplataforma.Infrastructure.Persistence;

namespace Microplataforma.Web.Controllers;

public class CandidateController : Controller
{
    private readonly ApplicationDbContext _context;

    public CandidateController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Profile(string slug)
    {
        var now = DateTimeOffset.UtcNow;

        var candidate = await _context.Candidates
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Contents
                .Where(content => content.IsPublished && content.Type == ContentType.Proposal)
                .OrderByDescending(content => content.PublishedAt)
                .ThenByDescending(content => content.Id))
            .Include(x => x.Events
                .Where(candidateEvent => candidateEvent.StartsAt >= now)
                .OrderBy(candidateEvent => candidateEvent.StartsAt)
                .ThenBy(candidateEvent => candidateEvent.Id))
            .Include(x => x.Materials
                .OrderBy(material => material.Title)
                .ThenBy(material => material.Id))
            .Include(x => x.SocialLinks
                .OrderBy(socialLink => socialLink.Platform)
                .ThenBy(socialLink => socialLink.Id))
            .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive);

        if (candidate is null)
            return NotFound();

        return View(candidate);
    }
}

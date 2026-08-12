using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var candidate = await _context.Candidates
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive);

        if (candidate is null)
            return NotFound();

        return View(candidate);
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microplataforma.Infrastructure.Persistence;
using Microplataforma.Web.Models;

namespace Microplataforma.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var candidates = await _context.Candidates
            .AsNoTracking()
            .Where(candidate => candidate.IsActive)
            .OrderBy(candidate => candidate.Slug == "eros" ? 0 : candidate.Slug == "chiara" ? 1 : 2)
            .ThenBy(candidate => candidate.Name)
            .ToListAsync();

        return View(candidates);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

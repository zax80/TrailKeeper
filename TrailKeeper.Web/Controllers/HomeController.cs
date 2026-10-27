using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrailKeeper.Services.Core.Contracts;
using TrailKeeper.Web.Models;

namespace TrailKeeper.Web.Controllers;

public class HomeController : Controller
{
    private const int LatestTrailsCount = 3;

    private readonly ITrailService trailService;

    public HomeController(ITrailService trailService)
    {
        this.trailService = trailService;
    }

    public async Task<IActionResult> Index()
    {
        var latestTrails = await trailService.GetLatestAsync(LatestTrailsCount);
        return View(latestTrails);
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
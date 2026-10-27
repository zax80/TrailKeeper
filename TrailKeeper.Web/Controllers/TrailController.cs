using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrailKeeper.Services.Core.Contracts;
using TrailKeeper.Web.ViewModels.Trails;

namespace TrailKeeper.Web.Controllers;

[Authorize]
public class TrailsController : Controller
{
    private readonly ITrailService trailService;
    private readonly ILookupService lookupService;

    public TrailsController(ITrailService trailService, ILookupService lookupService)
    {
        this.trailService = trailService;
        this.lookupService = lookupService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var trails = await trailService.GetAllAsync();
        return View(trails);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var model = await trailService.GetDetailsAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new TrailFormViewModel();
        await LoadLookupsAsync(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TrailFormViewModel model)
    {
        await ValidateLookupsAsync(model);

        if (!ModelState.IsValid)
        {
            await LoadLookupsAsync(model);
            return View(model);
        }

        await trailService.CreateAsync(model, GetUserId());
        TempData["Success"] = "Trail added successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await trailService.GetForEditAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        if (!await trailService.IsCreatorAsync(id, GetUserId()))
        {
            return Forbid();
        }

        await LoadLookupsAsync(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TrailFormViewModel model)
    {
        if (!await trailService.IsCreatorAsync(id, GetUserId()))
        {
            return Forbid();
        }

        await ValidateLookupsAsync(model);

        if (!ModelState.IsValid)
        {
            await LoadLookupsAsync(model);
            return View(model);
        }

        bool updated = await trailService.UpdateAsync(id, model);
        if (!updated)
        {
            return NotFound();
        }

        TempData["Success"] = "Trail updated successfully.";
        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var model = await trailService.GetForDeleteAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        if (!await trailService.IsCreatorAsync(id, GetUserId()))
        {
            return Forbid();
        }

        return View(model);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await trailService.IsCreatorAsync(id, GetUserId()))
        {
            return Forbid();
        }

        bool deleted = await trailService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        TempData["Success"] = "Trail deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    private async Task LoadLookupsAsync(TrailFormViewModel model)
    {
        model.Regions = await lookupService.GetRegionsAsync();
        model.Difficulties = await lookupService.GetDifficultiesAsync();
    }

    private async Task ValidateLookupsAsync(TrailFormViewModel model)
    {
        if (!await lookupService.RegionExistsAsync(model.RegionId))
        {
            ModelState.AddModelError(nameof(model.RegionId), "Selected region does not exist.");
        }

        if (!await lookupService.DifficultyExistsAsync(model.DifficultyId))
        {
            ModelState.AddModelError(nameof(model.DifficultyId), "Selected difficulty does not exist.");
        }
    }
}
# TrailKeeper

Hiking trail catalog for Bulgarian mountains. ASP.NET Core 8 MVC, EF Core, SQL Server, Identity.

Course project for SoftUni ASP.NET Fundamentals (October 2026).

## What it does

Anyone can browse trails and see details: region, difficulty, length, elevation gain, duration.
Logged-in users can add trails. A trail can be edited or deleted only by the user who created it.

## Running locally

Requirements: .NET 8 SDK, SQL Server LocalDB, `dotnet-ef` 8.x.

```bash
dotnet tool install --global dotnet-ef --version 8.*   # if not installed

git clone https://github.com/zax80/TrailKeeper.git
cd TrailKeeper
dotnet ef database update --project TrailKeeper.Data --startup-project TrailKeeper.Web
dotnet run --project TrailKeeper.Web
```

The connection string in `TrailKeeper.Web/appsettings.json` points to `(localdb)\MSSQLLocalDB` with
Windows authentication. Nothing else needs to be configured: no secrets, no environment variables.
For another SQL Server instance, change `Server=` only.

From Visual Studio: set `TrailKeeper.Web` as startup project, run `Update-Database` in Package
Manager Console with `TrailKeeper.Data` as default project, then F5.

## Demo account

```
demo@trailkeeper.com
Demo123
```

The demo user owns the six seeded trails, so you can try edit/delete right away. Registering a new
account also works; email confirmation is off.

## Solution layout

```
TrailKeeper.Web              controllers, views, Program.cs
TrailKeeper.Web.ViewModels   input/output models + validation attributes
TrailKeeper.Services.Core    ITrailService, ILookupService and implementations
TrailKeeper.Data             DbContext, entity configurations, migrations, seed
TrailKeeper.Data.Models      Trail, Region, Difficulty
TrailKeeper.GCommon          constants shared across projects
```

References only point downward. Controllers know about service interfaces, not the DbContext.

## Data model

`Trail` belongs to one `Region`, one `Difficulty` and one creator (`IdentityUser`).
Regions (5) and difficulties (4) are lookup data, seeded with the initial migration.

## Notes

- **Delete behavior is `Restrict`** on all trail foreign keys. A region that still has trails
  can't be deleted by accident.
- **Views never get entities.** Each page has its own view model; one `TrailFormViewModel` is
  shared by Create and Edit through the `_TrailForm` partial.
- **Validation runs twice.** Data annotations give client-side checks via jQuery Unobtrusive
  Validation; the controller also checks that the selected region and difficulty actually exist,
  since a POST can be crafted.
- **Ownership is checked on GET and POST.** Hiding the Edit button isn't enough; the POST action
  verifies the creator too and returns 403 otherwise.
- **The demo user's password hash is a constant.** `HasData` compares seed values between
  migrations, so generating the hash at runtime would produce a new migration every time.
- **Request culture is fixed to `en-US`** so decimal input (`7.5`) is parsed the same way on
  every machine.

## Pages

| Route | Access |
| --- | --- |
| `/` | public, latest 3 trails |
| `/Trails`, `/Trails/Details/{id}` | public |
| `/Trails/Create` | authenticated |
| `/Trails/Edit/{id}`, `/Trails/Delete/{id}` | trail creator |
| `/Home/About` | public |
| `/Identity/Account/Login`, `/Register` | public |
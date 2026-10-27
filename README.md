# TrailKeeper

Hiking trail catalog for Bulgarian mountains. ASP.NET Core 8 MVC, EF Core, SQL Server, Identity.

Course project for SoftUni ASP.NET Fundamentals (October 2026).

## What it does

Anyone can browse trails and see details: region, difficulty, length, elevation gain, duration.
Logged-in users can add trails. A trail can be edited or deleted only by the user who created it.

## Running locally

### 1. Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) — check with `dotnet --version`
- SQL Server LocalDB — comes with Visual Studio (*ASP.NET and web development* workload).
  Check with `sqllocaldb info`; the output should list `MSSQLLocalDB`.
- EF Core CLI tool:
  ```bash
  dotnet tool install --global dotnet-ef --version 8.*
  ```

### 2. Get the code

```bash
git clone https://github.com/<your-username>/TrailKeeper.git
cd TrailKeeper
```

### 3. Create the database

```bash
dotnet ef database update --project TrailKeeper.Data --startup-project TrailKeeper.Web
```

This creates the `TrailKeeper` database on LocalDB and fills it with regions, difficulties,
six sample trails and the demo user. No connection string changes are needed.

### 4. Run

```bash
dotnet run --project TrailKeeper.Web
```

Open the `https://localhost:...` address printed in the console.

### Using Visual Studio instead

1. Open `TrailKeeper.slnx`.
2. Right-click `TrailKeeper.Web` → **Set as Startup Project**.
3. **Tools → NuGet Package Manager → Package Manager Console**, choose `TrailKeeper.Data`
   in the *Default project* dropdown and run `Update-Database`.
4. Press **F5**.

### Using another SQL Server

The connection string is in `TrailKeeper.Web/appsettings.json` and uses Windows authentication,
so no passwords or environment variables are needed. To use a full SQL Server instead of LocalDB,
change only `Server=(localdb)\MSSQLLocalDB` (for example to `Server=.` or `Server=.\SQLEXPRESS`)
and run step 3 again.

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
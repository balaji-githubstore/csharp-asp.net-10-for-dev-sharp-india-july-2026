using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization();

// 1. Register localization and specify the folder containing your translation files
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// 2. Define the languages your application supports
var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("es-ES"),
    new CultureInfo("fr-FR")
};

// 3. Configure the middleware options
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("fr-FR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

// https://localhost:5001/?culture=fr-FR&ui-culture=fr-FR

// 4. Inject the middleware into the HTTP pipeline
app.UseRequestLocalization(localizationOptions);

// Sample Minimal API Endpoint utilizing the localizer
// app.MapGet("/api/welcome", (IStringLocalizer<Program> localizer) =>
// {
//     return Results.Ok(new { Message = localizer["WelcomeMessage"].Value });
// });

app.MapRazorPages();

app.Run();
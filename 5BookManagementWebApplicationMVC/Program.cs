
//configure logging, DI, kestrel web server, hosting environment
var builder = WebApplication.CreateBuilder(args);

//service for validation attributes [Required] 
builder.Services.AddValidation();

//build mvc services in DI container (model, view, controller, validation)
builder.Services.AddControllersWithViews();

//webapplication builder object will be created with the configuration details
var app = builder.Build();

//Adds the routing middleware to match incoming URLs to endpoints.
app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

app.Run();

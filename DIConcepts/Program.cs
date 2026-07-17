var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyService>();
builder.Services.AddSingleton<MyService>();
builder.Services.AddScoped<MyService>();

var app = builder.Build();

app.MapGet("/", (MyService transient, MyService singleton, MyService scoped) =>
{
    return $@"
=== Transient ===
GUID: {transient.Id}
Hash Code: {transient.GetHashCode()}

=== Singleton ===
GUID: {singleton.Id}
Hash Code: {singleton.GetHashCode()}

=== Scoped ===
GUID: {scoped.Id}
Hash Code: {scoped.GetHashCode()}
";
});

app.Run();

public class MyService
{
    public Guid Id { get; } = Guid.NewGuid();
}

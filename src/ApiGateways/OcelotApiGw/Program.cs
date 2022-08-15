using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
var app = builder.Build();

builder.Configuration.AddJsonFile($"ocelot.{app.Environment.EnvironmentName}.json", true, true);

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();

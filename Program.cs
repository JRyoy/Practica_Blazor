using BlazorApp.Components;
using Blazor.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<AplicacionDbContext>(options => options.UseNpgsql(connectionString));

var opciones = new DbContextOptionsBuilder<AplicacionDbContext>();

opciones.UseNpgsql(connectionString);

var contexto = new AplicacionDbContext(opciones.Options);

    contexto.Database.EnsureCreated();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

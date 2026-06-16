using Blazor.FP.App.Components;
using Blazor.FP.Datacontext.Datacontext;
using EF.Core.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using PasswordGenerator;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.ConfigureData<Forgotcontext>();
builder.Services.AddDbContextFactory<Forgotcontext>();

builder.Services.AddPasswordGenerator(options =>
{
    options.Length = 4;
    options.IncludeNumeric = true;
});

builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<Forgotcontext>();
    services.Database.Migrate();
}

app.Run();
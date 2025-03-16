//using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Meditor.Behavior;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register MediatR
//builder.Services.AddMediatR(typeof(YourHandlerClass).Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); // Register handlers from the current assembly
builder.Services.AddMediatR(typeof(Program).Assembly); // Register handlers from the current assembly


// Register Behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

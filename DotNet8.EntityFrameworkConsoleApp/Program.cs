using DotNet8.EntityFrameworkConsoleApp;
using DotNet8.EntityFrameworkConsoleApp.DbService.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddScoped<Connection>()
    .AddDbContext<AppDbContext>()
    .AddScoped<EFCoreService>()
    .BuildServiceProvider();
EFCoreService efCoreService = services.GetRequiredService<EFCoreService>();
efCoreService.Run();
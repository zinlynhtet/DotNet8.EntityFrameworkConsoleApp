using DotNet8.EntityFrameworkConsoleApp.Models;
using DotNet8.EntityFrameworkConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<AppDBContext>()
    .AddScoped<EFCoreService>()
    .BuildServiceProvider();
EFCoreService efCoreService = services.GetRequiredService<EFCoreService>();
efCoreService.Run();
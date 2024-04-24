using DotNet8.EntityFrameworkConsoleApp.DbService.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<AppDbContext>()
    .BuildServiceProvider();
var EFCoreService = services.GetRequiredService<AppDbContext>();
EFCoreService.Run();
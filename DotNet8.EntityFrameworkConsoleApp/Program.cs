using DotNet8.EntityFrameworkConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<AppDBContext>()
    .AddScoped<EFCoreService>()
    .BuildServiceProvider();
EFCoreService efCoreService = services.GetRequiredService<EFCoreService>();
efCoreService.Run();
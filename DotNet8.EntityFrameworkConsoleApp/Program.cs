var services = new ServiceCollection()
    .AddDbContext<AppDBContext>()
    .AddScoped<EFCoreService>()
    .BuildServiceProvider();
EFCoreService efCoreService = services.GetRequiredService<EFCoreService>();
efCoreService.Run();
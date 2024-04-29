using DotNet8.EntityFrameworkConsoleApp.Models;

namespace DotNet8.EntityFrameworkConsoleApp.Services;

public class EFCoreService
{
    private readonly AppDBContext _context;

    public EFCoreService(AppDBContext context)
    {
        _context = new AppDBContext();
    }

    public void Run()
    {
        Read();
    }

    private void Read()
    {
        List<BlogDataModel> lst = _context.Blogs.ToList();
        foreach (BlogDataModel item in lst)
        {
            item.ToConsole();
        }
    }
}

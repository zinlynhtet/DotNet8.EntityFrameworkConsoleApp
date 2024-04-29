using DotNet8.EntityFrameworkConsoleApp.DbService.Models;

namespace DotNet8.EntityFrameworkConsoleApp;

public class EFCoreService
{
    private readonly AppDbContext _context;
    public EFCoreService(AppDbContext context)
    {
        _context = context;
    }

    public void Run()
    {
        Read();
    }

    private void Read()
    {
        List<TblBlog> lst = _context.TblBlogs.ToList();
        foreach (TblBlog item in lst)
        {
            item.ToConsole();
        }
    }
}

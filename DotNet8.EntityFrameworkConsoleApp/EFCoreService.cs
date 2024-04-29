using DotNet8.EntityFrameworkConsoleApp.ConnectionService;

namespace DotNet8.EntityFrameworkConsoleApp;

public class EFCoreService
{
    private readonly Connection _context;

    public EFCoreService(Connection context)
    {
        _context = new Connection();
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

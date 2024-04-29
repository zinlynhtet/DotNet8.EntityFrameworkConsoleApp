namespace DotNet8.EntityFrameworkConsoleApp;

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

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
        //Create();
        //Delete();
        //Update();
    }

    private void Read()
    {
        List<BlogDataModel> lst = _context.Blogs.AsNoTracking().ToList();
        foreach (BlogDataModel item in lst)
        {
            item.ToConsole();
        }
    }

    private void Edit()
    {
        Console.Write("Enter blog Id: ");
        int id = Console.ReadLine().ToInt();
        var item = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            string message = "No data found";
            message.ToConsoleMessage();
            return;
        }

        item.ToConsole();
    }

    #region user input

    private (string, string, string) UserInput()
    {
        Console.Write("Enter blog title: ");
        string title = Console.ReadLine();
        Console.Write("Enter blog author: ");
        string author = Console.ReadLine();
        Console.Write("Enter blog content: ");
        string content = Console.ReadLine();
        return (title, author, content);
    }

    #endregion

    private void Create()
    {
        var (title, author, content) = UserInput();
        BlogDataModel model = new BlogDataModel
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        _context.Blogs.Add(model);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        message.ToConsoleMessage();
    }

    private void Update()
    {
        Console.Write("Enter blog Id: ");
        int id = Console.ReadLine().ToInt();

        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            string message1 = "No data found";
            message1.ToConsoleMessage();
            return;
        }

        var (title, author, content) = UserInput();
        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;

        int result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    private void Delete()
    {
        Console.Write("Enter blog Id: ");
        int id = Console.ReadLine().ToInt();
        var item = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            string message1 = "No data found";
            message1.ToConsoleMessage();
            return;
        }

        _context.Blogs.Remove(item);
        _context.Entry(item).State = EntityState.Deleted;
        int result = _context.SaveChanges();
        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        message.ToConsoleMessage();
    }
}
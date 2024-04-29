using DotNet8.EntityFrameworkConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

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
    }

    private void Read()
    {
        List<BlogDataModel> lst = _context.Blogs.AsNoTracking().ToList();
        foreach (BlogDataModel item in lst)
        {
            item.ToConsole();
        }
    }
    private void Edit(int id)
    {
        BlogDataModel? item = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            string message = "No data found";
            message.ToConsoleMessage();
            return;
        }
        item.ToConsole();
    }

    #region user input
    private static string? UserInput(out string? author, out string? content)
    {
        Console.Write("Enter blog title: ");
        string title = Console.ReadLine();

        Console.Write("Enter blog author: ");
        author = Console.ReadLine();

        Console.Write("Enter blog content: ");
        content = Console.ReadLine();
        return title;
    }

    #endregion
    private void Create()
    {
        var title = UserInput(out var author, out var content);
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
    private void Delete(int id)
    {
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

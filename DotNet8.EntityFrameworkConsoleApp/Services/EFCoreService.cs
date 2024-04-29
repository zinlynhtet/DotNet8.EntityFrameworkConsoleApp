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
        List<BlogDataModel> lst = _context.Blogs.ToList();
        foreach (BlogDataModel item in lst)
        {
            item.ToConsole();
        }
    }
    private void Edit(int id)
    {
        BlogDataModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
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
}

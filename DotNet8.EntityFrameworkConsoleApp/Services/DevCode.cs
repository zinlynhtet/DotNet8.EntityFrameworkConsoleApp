namespace DotNet8.EntityFrameworkConsoleApp.Services;

public static class DevCode
{
    public static void ToConsole(this object item)
    {
        dynamic dynamicItem = item;
        if (dynamicItem is not null)
        {
            Console.WriteLine($"BlogId: {dynamicItem.BlogId}");
            Console.WriteLine($"BlogTitle: {dynamicItem.BlogTitle}");
            Console.WriteLine($"BlogAuthor: {dynamicItem.BlogAuthor}");
            Console.WriteLine($"BlogContent: {dynamicItem.BlogContent}");
        }
        else
        {
            Console.WriteLine("Object is null.");
        }

    }
    public static void ToConsoleMessage(this object item)
    {
        dynamic dynamicItem = item;

        Console.WriteLine(dynamicItem);
    }

}

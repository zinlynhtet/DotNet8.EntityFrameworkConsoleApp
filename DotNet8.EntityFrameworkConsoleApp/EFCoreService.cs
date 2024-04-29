using DotNet8.EntityFrameworkConsoleApp.DbService.Models;
using System;

namespace DotNet8.EntityFrameworkConsoleApp;

public class EFCoreService
{
    private readonly Connection _connection;

    public EFCoreService(Connection connection)
    {
        _connection = new Connection();
    }

    public void Run()
    {
        Read();
    }

    private void Read()
    {
        var lst = _connection.TblBlogs.ToList();
        foreach (TblBlog item in lst)
        {
            item.ToConsole();
        }
    }
}

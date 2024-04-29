using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace DotNet8.EntityFrameworkConsoleApp.DbService.Models;

public class Connection : DbContext
{
    //public string ConnectionString()
    //{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
    }
    //var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
    //    {
    //        DataSource = ".",
    //        InitialCatalog = "TestDb",
    //        UserID = "sa",
    //        Password = "sasa@123",
    //        TrustServerCertificate = true
    //    };
    //    return sqlConnectionStringBuilder.ConnectionString;
    //}
    public DbSet<TblBlog> TblBlogs { get; set; }

}

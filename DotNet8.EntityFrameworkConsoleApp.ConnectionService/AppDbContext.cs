using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DotNet8.EntityFrameworkConsoleApp
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {

                    DataSource = ".", // sever name
                    InitialCatalog = "TestDb", //database name
                    UserID = "sa",
                    Password = "sasa@123",
                    TrustServerCertificate = true
                };
                optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            }
        }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}

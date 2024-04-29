using Microsoft.Data.SqlClient;
namespace DotNet8.EntityFrameworkConsoleApp.DbService.Models
{
    public class Connection
    {
        public string ConnectionString()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}

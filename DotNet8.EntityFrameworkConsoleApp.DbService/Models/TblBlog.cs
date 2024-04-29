using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNet8.EntityFrameworkConsoleApp.DbService.Models;

[Table("TblBlog")]
public  class TblBlog
{
    [Key]
    [Column("BlogId")]
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}


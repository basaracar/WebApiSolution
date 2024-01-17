using Microsoft.EntityFrameworkCore;
using WebApiSolution.Models;

namespace WebApiSolution.Models
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Question> QuestionItems { get; set; } = null!;
}
}



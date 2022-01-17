using Abby_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Abby_Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; } 
    }
}

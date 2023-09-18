using CRUD_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EntityFramework.DataContext
{
    public class ApplicationDbContext : DbContext

    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        { 
         
        
        }

        public DbSet<Category> categories { get; set; } 

    }
}

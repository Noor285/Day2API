using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public class APIdbContext : DbContext
    {
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public APIdbContext(DbContextOptions<APIdbContext> options) : base(options)
        { 

        }

        public APIdbContext()
        {
        }
    }
}

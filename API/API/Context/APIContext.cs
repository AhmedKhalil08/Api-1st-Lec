using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class APIContext:DbContext
    {
        public APIContext(DbContextOptions<APIContext> options):base(options)
        {
            
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}

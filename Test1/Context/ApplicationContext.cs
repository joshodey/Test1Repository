using Microsoft.EntityFrameworkCore;
using Test1.Model;

namespace Test1.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Employee> employee { get; set; }
    }
}

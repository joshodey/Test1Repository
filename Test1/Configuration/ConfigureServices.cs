using Microsoft.EntityFrameworkCore;
using Test1.Context;

namespace Test1.Configuration
{
    public static class ConfigureServices
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.GetConnectionString("DefaultConnection")));
        }
    }
}

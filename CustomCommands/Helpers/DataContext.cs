using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CustomCommands.Entities;
using CustomCommands.Models;

namespace CustomCommands.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebAPIFakeDB"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Command> Commands { get; set; }
    }
}
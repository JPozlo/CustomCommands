using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CustomCommands.Helpers
{
    public class SqliteDataContext : DataContext
    {

        private readonly IConfiguration _configuration;
        public SqliteDataContext(IConfiguration configuration) : base(configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(_configuration.GetConnectionString("WebAPIFakeDB"));
        }
    }
}
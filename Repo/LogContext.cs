using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParseLogFile.Model;

namespace ParseLogFile.Repo
{
    public class LogContext : DbContext
    {
        readonly IConfigurationRoot _config = null;
        public LogContext( IConfigurationRoot config)
        {
            _config = config;
        }
        public DbSet<InConnectionLog> InConnectionLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DataMartConnection"));
        }
    }
}

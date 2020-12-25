using Microsoft.EntityFrameworkCore;
using UniAssist.Entities;

namespace UniAssist.Database
{
    /// <summary>
    /// Application Database Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initialize Context
        /// </summary>
        /// <param name="options">Database Context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        /// <value>
        /// Periods
        /// </value>
        public DbSet<Period> Periods { get; set; }
        
        /// <value>
        /// Config
        /// </value>
        public DbSet<Config> Config { get; set; }
    }
}
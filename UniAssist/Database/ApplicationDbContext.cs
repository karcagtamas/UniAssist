using Microsoft.EntityFrameworkCore;
using UniAssist.Entities;

namespace UniAssist.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Period> Periods { get; set; }
    }
}
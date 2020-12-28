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
        /// Global Tasks
        /// </value>
        public DbSet<GlobalTask> GlobalTasks { get; set; }
        
        /// <value>
        /// Global Notes
        /// </value>
        public DbSet<GlobalNote> GlobalNotes { get; set; }
        
        /// <value>
        /// Period Tasks
        /// </value>
        public DbSet<PeriodTask> PeriodTasks { get; set; }
        
        /// <value>
        /// Period Notes
        /// </value>
        public DbSet<PeriodNote> PeriodNotes { get; set; }
        
        /// <value>
        /// Subject Tasks
        /// </value>
        public DbSet<SubjectTask> SubjectTasks { get; set; }
        
        /// <value>
        /// Subject Notes
        /// </value>
        public DbSet<SubjectNote> SubjectNotes { get; set; }
        
        /// <value>
        /// Folders
        /// </value>
        public DbSet<Folder> Folders { get; set; }
        
        /// <value>
        /// Files
        /// </value>
        public DbSet<File> Files { get; set; }
        
        /// <value>
        /// Subjects
        /// </value>
        public DbSet<Subject> Subjects { get; set; }

        /// <value>
        /// Periods
        /// </value>
        public DbSet<Period> Periods { get; set; }
        
        /// <value>
        /// Config
        /// </value>
        public DbSet<Config> Config { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PeriodTask>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            modelBuilder.Entity<PeriodNote>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Notes)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();

            modelBuilder.Entity<SubjectTask>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            modelBuilder.Entity<SubjectNote>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Notes)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();

            modelBuilder.Entity<Folder>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Folders)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Folder>()
                .HasOne(x => x.ParentFolder)
                .WithMany(x => x.SubFolders)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            modelBuilder.Entity<File>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Files)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<File>()
                .HasOne(x => x.ParentFolder)
                .WithMany(x => x.Files)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            modelBuilder.Entity<Subject>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Subjects)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
        }
    }
}
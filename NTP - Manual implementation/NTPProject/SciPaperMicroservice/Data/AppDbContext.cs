using Microsoft.EntityFrameworkCore;
using SciPaperMicroservice.Models;

namespace SciPaperMicroservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<SciPaper>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Section>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<SciPaper>()
                .HasMany(s => s.Sections)
                .WithOne()
                .HasForeignKey(s => s.SciPaperId)
                .OnDelete(DeleteBehavior.Cascade);
                  
        }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=scipaper;Pooling=true;");*/

        public DbSet<SciPaper> SciPapers { get; set; }
        public DbSet<Section> Sections { get; set; }

    }
}

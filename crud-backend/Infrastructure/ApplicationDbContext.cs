using Microsoft.EntityFrameworkCore;
using Entity;



namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // public virtual DbSet<Cartable> Cartables { get; set; }
        public virtual DbSet<Elanat> Elanats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elanat>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateFrom).IsFixedLength();

                entity.Property(e => e.DateTo).IsFixedLength();
            });





        }
    }
}

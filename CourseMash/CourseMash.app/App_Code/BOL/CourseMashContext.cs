using Microsoft.EntityFrameworkCore;

namespace CourseMash.app.App_Code.BOL
{
    public class CourseMashContext : DbContext
    {

        public CourseMashContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(SecretConfig.ConnectionString, new MySqlServerVersion(SecretConfig.Version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false);

                entity.Property(e => e.IsApproved)
                .HasDefaultValue(true);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.IsActive)
                .HasDefaultValue(true);
            });

            modelBuilder.Entity<School>()
                .HasMany(c => c.Users)
                .WithOne(e => e.School)
                .IsRequired(false);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}

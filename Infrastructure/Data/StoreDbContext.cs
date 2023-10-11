using BusinessLogic.Entities;
using Core.Helpers;
using DataAccess.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    internal class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {

        }
        public StoreDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = ConnectionStringBuilder.GenerateConnectionString();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PhoneConfiguration());

            modelBuilder.SeedColors();
            modelBuilder.SeedPhones();
        }

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
    }
}

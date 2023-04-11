using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Configurations;

namespace Repositories
{
    public sealed class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(nameof(Object));
            modelBuilder.ApplyConfiguration(new OiseauConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<LieuObservation>? LieuxObservations { get; set; }
        public DbSet<Observation>? Observations { get; set; }
        public DbSet<Oiseau>? Oiseaux { get; set; }
    }
}

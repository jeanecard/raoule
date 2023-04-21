using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Configurations;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
    : base(options)
        {
        }

        public RepositoryContext()
        { }

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
        public virtual DbSet<Oiseau>? Oiseaux { get; set; }
    }
}

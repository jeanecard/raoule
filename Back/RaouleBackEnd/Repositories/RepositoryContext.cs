using Entities;
using Microsoft.EntityFrameworkCore;

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
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<LieuObservation>? LieuxObservations { get; set; }
        public DbSet<Observation>? Observations { get; set; }
        public DbSet<Oiseau>? Oiseaux { get; set; }
    }
}

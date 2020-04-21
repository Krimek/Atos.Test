using Atos.Test.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Atos.Test.Infrastructure
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }

        public virtual DbSet<Bank> Bank { get; set; }

        public virtual DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                        .HasMany(e => e.People)
                        .WithOne(e => e.Bank)
                        .HasForeignKey(e => e.IDBank);

            modelBuilder.Entity<People>()
                        .HasOne(e => e.Bank)
                        .WithMany(e => e.People)
                        .HasForeignKey(e => e.IDBank);
        }
    }
}

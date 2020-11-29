using ImbdDomain.Models;
using ImdbInfraData.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImdbInfraData.Context
{
    public class ImdbContext : DbContext
    {
        public ImdbContext(DbContextOptions<ImdbContext> options)
            : base(options)
        {
        }

        private void UpdateEntityDates()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is ImdbEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((ImdbEntity)entity.Entity).CreatedAt = now;
                }
                ((ImdbEntity)entity.Entity).UpdatedAt = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(UserSeed.GetData());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityDates();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> User { get; set; }
    }
}

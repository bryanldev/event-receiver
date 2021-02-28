using System.Linq;
using System.Reflection;
using Domain.Entities.SensorEventAggregate;
using Flunt.Notifications;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SensorEvent> SensorEvent { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SensorEvent>(new SensorEventConfiguration().Configure);
            modelBuilder.Entity<Tag>(new TagConfiguration().Configure);
            modelBuilder.Ignore<Notification>();
        }
    }
}
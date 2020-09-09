using System.Linq;
using System.Reflection;
using EventReceiver.Domain.Entities;
using EventReceiver.Domain.Models;
using EventReceiver.Infra.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 618

namespace EventReceiver.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SensorEvent> SensorEvent { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbQuery<TagRegionResponseModel> TagRegionResponseModel { get; set; }
        public DbQuery<TagSensorNameResponseModel> TagSensorNameResponseModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SensorEvent>(new SensorEventMap().Configure);
            modelBuilder.Entity<Tag>(new TagMap().Configure);

            var entities = Assembly
                .Load("EventReceiver.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "EventReceiver.Domain.Entities" && w.BaseType?.BaseType == typeof(Notifiable));

            foreach (var item in entities)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }
        }
    }
}

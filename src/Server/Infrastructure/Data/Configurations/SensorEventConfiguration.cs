using Domain.Entities.SensorEventAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class SensorEventConfiguration : IEntityTypeConfiguration<SensorEvent>
    {
        public void Configure(EntityTypeBuilder<SensorEvent> builder)
        {
            builder.ToTable("SensorEvent");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Data)
                .HasColumnName("Valor")
                .HasMaxLength(50)
                .HasConversion(prop => prop.ToString(), prop => new SensorData(prop));

            builder.Property(prop => prop.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasMaxLength(10);

            builder.Property(prop => prop.Timestamp)
                .IsRequired()
                .HasColumnName("Timestamp")
                .HasMaxLength(20)
                .HasConversion(prop => prop.Time, prop => new Timestamp(prop));

            builder
                .HasOne(prop => prop.Tag)
                .WithOne(prop => prop.SensorEvent);

        }
    }
}
using EventReceiver.Domain.Entities;
using EventReceiver.Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventReceiver.Infra.Data.Mapping
{
    internal class SensorEventMap : IEntityTypeConfiguration<SensorEvent>
    {
        public void Configure(EntityTypeBuilder<SensorEvent> builder)
        {
            builder.ToTable("SensorEvent");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Valor)
                .HasColumnName("Valor")
                .HasMaxLength(50)
                .HasConversion(prop => prop.ToString(), prop => new Valor(prop));

            builder.Property(prop => prop.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasMaxLength(10);

            builder.Property(prop => prop.Timestamp)
                .IsRequired()
                .HasColumnName("Timestamp")
                .HasMaxLength(20)
                .HasConversion(prop=> prop.Time, prop => new Timestamp(prop));
            
            builder
                .HasOne(prop => prop.Tag)
                .WithOne(prop => prop.SensorEvent);
            
        }
    }
}

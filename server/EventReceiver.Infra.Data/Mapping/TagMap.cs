using EventReceiver.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventReceiver.Infra.Data.Mapping
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Country)
                .IsRequired()
                .HasColumnName("Country")
                .HasMaxLength(50);

            builder.Property(prop => prop.Region)
                .IsRequired()
                .HasColumnName("Region")
                .HasMaxLength(50);

            builder.Property(prop => prop.SensorName)
                .IsRequired()
                .HasColumnName("SensorName")
                .HasMaxLength(50);

            builder
                .HasOne(prop => prop.SensorEvent)
                .WithOne(prop => prop.Tag)
                .HasForeignKey<Tag>(p => p.SensorEventId);
        }
    }
}
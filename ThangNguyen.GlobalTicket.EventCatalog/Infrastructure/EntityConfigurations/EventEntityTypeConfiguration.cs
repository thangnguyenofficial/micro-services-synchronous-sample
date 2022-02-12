using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.EntityConfigurations
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            builder.HasKey(ci => ci.EventId);

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasOne(ci => ci.Category)
                .WithMany(e => e.Events)
                .HasForeignKey(ci => ci.CategoryId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(ci => ci.CategoryId);

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}

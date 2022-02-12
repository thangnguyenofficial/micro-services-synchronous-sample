using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.EntityConfigurations
{
    public class BasketLineEntityTypeConfiguration : IEntityTypeConfiguration<BasketLine>
    {
        public void Configure(EntityTypeBuilder<BasketLine> builder)
        {
            builder.ToTable("BasketLine");

            builder.HasKey(ci => ci.BasketLineId);

            builder.Property(cb => cb.Quantity)
                .IsRequired();

            builder.Property(cb => cb.Price)
                .IsRequired()
                .HasColumnType("money");

            builder.HasOne(ci => ci.Event);

            builder.HasOne(ci => ci.Basket)
                .WithMany(e => e.BasketLines)
                .HasForeignKey(ci => ci.BasketId);
        }
    }
}

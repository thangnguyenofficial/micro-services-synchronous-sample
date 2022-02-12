using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.EntityConfigurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.HasKey(ci => ci.BasketId);

            builder.Property(cb => cb.UserId)
                .IsRequired();
        }
    }
}

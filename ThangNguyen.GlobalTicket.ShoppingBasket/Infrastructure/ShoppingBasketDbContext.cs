using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.ShoppingBasket.Entities;
using ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.EntityConfigurations;

namespace ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options) : base(options)
        {

        }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketLine> BasketLines { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BasketEntityTypeConfiguration());
            builder.ApplyConfiguration(new BasketLineEntityTypeConfiguration());
            builder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }
    }
}

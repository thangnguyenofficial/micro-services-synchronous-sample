using System;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;
using ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.EntityConfigurations;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure
{
    public class EventCatalogDbContext : DbContext
    {
        public EventCatalogDbContext(DbContextOptions<EventCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            builder.ApplyConfiguration(new EventEntityTypeConfiguration());

            #region category id definition

            var concertGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}");
            var musicalGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA315}");
            var playGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA316}");

            #endregion

            #region add categories data

            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });

            #endregion

            #region add events data

            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "/img/banjo.jpg",
                CategoryId = concertGuid
            });

            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
                Name = "The State of Affairs: Michael Live!",
                Price = 85,
                Artist = "Michael Johnson",
                Date = DateTime.Now.AddMonths(9),
                Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "/img/michael.jpg",
                CategoryId = concertGuid
            });


            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
                Name = "To the Moon and Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = DateTime.Now.AddMonths(8),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImageUrl = "/img/musical.jpg",
                CategoryId = musicalGuid
            });

            #endregion
        }
    }
}
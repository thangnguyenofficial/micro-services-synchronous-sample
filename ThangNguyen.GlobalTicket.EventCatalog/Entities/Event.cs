using System;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.EventCatalog.Entities
{
    public class Event
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public int Price { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public virtual  Category Category { get; set; }
    }
}

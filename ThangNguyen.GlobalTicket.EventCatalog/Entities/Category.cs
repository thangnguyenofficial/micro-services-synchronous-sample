using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThangNguyen.GlobalTicket.EventCatalog.Entities
{
    public class Category
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Event> Events {  get; set; }

        public Category()
        {
            Events = new List<Event>();
        }
    }
}

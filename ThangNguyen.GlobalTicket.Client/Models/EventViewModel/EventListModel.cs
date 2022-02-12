using System;
using System.Collections.Generic;
using ThangNguyen.GlobalTicket.Client.Models.Api;

namespace ThangNguyen.GlobalTicket.Client.Models.EventViewModel
{
    public class EventListModel
    {
        public IEnumerable<Event> Events { get; set; }

        public Guid SelectedCategory { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public int NumberOfItems { get; set; }
    }
}

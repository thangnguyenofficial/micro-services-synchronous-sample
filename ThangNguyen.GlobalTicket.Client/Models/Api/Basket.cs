﻿using System;

namespace ThangNguyen.GlobalTicket.Client.Models.Api
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        public Guid UserId { get; set; }

        public int NumberOfItems { get; set; }
    }
}

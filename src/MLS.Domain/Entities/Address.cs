﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
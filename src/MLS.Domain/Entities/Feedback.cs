﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public int FeedbackId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Entities.Customer Customer { get; set; }
    }
}
﻿namespace MLS.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
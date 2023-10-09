﻿namespace Bookular.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Isbn { get; set; }
        public long? AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}

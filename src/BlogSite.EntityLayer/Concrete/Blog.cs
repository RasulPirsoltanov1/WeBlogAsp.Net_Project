﻿namespace BlogSite.EntityLayer.Concrete
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ThumbnaiImage { get; set; }
        public string? Image { get; set; }
    }
}
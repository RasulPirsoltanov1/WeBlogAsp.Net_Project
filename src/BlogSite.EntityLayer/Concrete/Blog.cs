namespace BlogSite.EntityLayer.Concrete
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ThumbnaiImage { get; set; }
        public string? Image { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public AppUser? Writer { get; set; }
        public int? WriterId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}

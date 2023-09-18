namespace BlogSite.EntityLayer.Concrete
{
    public class Writer : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
    }
}

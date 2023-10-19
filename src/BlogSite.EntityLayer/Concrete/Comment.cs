namespace BlogSite.EntityLayer.Concrete
{
    public class Comment : BaseEntity
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogScore{ get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public AppUser? AppUser{ get; set; }
    }
}

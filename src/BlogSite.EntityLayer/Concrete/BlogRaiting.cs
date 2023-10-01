namespace BlogSite.EntityLayer.Concrete
{
    public class BlogRaiting : BaseEntity
    {
        public int BlogId{ get; set; }
        public int TotalScore{ get; set; }
        public int TotalRaitingCount{ get; set; }
    }
}

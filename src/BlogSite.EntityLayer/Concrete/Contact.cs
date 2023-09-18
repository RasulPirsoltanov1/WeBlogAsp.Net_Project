namespace BlogSite.EntityLayer.Concrete
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Mail{ get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

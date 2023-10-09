namespace BlogSite.EntityLayer.Concrete
{
    public class Message2 : BaseEntity
    {
        public int SenderId { get; set; }
        public AppUser? Sender { get; set; }
        public int RecieverId { get; set; }
        public AppUser? Reciever { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
    }
}

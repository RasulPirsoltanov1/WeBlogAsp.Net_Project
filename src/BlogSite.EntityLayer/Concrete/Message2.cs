namespace BlogSite.EntityLayer.Concrete
{
    public class Message2 : BaseEntity
    {
        public int SenderId { get; set; }
        public Writer? Sender { get; set; }
        public int RecieverId { get; set; }
        public Writer? Reciever { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
    }
}

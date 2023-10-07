namespace BlogSite.EntityLayer.Concrete
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
        public string? Role { get; set; }

    }
}

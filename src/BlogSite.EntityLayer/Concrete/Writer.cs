namespace BlogSite.EntityLayer.Concrete
{
    public class Writer : BaseEntity
    {
        public string Name { get; set; }
        public string? About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
        public int? CountryId { get; set; }
		public Country? Country { get; set; }
        public virtual ICollection<Message2>? SendMessages { get; set; }
        public virtual ICollection<Message2>? RecieveMessages { get; set; }
	}
}

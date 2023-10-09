namespace BlogSite.EntityLayer.Concrete
{
	public class Country : BaseEntity
	{
		public string Name { get; set; }
		public List<AppUser> AppUsers { get; set; }
	}
}

using Microsoft.AspNetCore.Identity;

namespace AccountingSystem.Model.System
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

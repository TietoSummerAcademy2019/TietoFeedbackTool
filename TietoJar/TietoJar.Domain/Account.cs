using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoJar.Domain
{
	public class Account
	{
		[Key]
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public List<Survey> Surveys { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoFeedbackTool.Domain
{
	public class Account
	{
		[Key]
		public string Login { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string QuestionKey { get; set; }
		public List<Question> Questions { get; set; }
	}
}
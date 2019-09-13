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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string QuestionsKey { get; set; }
		public List<Question> Questions { get; set; }
	}
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoFeedbackTool.Domain
{
	public class Account
	{
		[Key]
		[MaxLength(50)]
		public string Login { get; set; }
		[MaxLength(30)]
		public string Name { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[MaxLength(32)]
		public string QuestionsKey { get; set; }
		public List<Question> Questions { get; set; }
	}
}
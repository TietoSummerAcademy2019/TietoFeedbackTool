using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoFeedbackTool.Domain
{
	public class Account
	{
		[Key]
		public string Login { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string SurveyKey { get; set; }
		public List<SurveyPuzzle> SurveyPuzzles { get; set; }
	}
}
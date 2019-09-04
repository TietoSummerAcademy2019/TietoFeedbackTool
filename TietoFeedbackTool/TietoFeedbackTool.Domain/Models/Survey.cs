using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoFeedbackTool.Domain
{
	public class Survey
	{
		[Key]
		public string SurveyKey { get; set; }
		[ForeignKey("Login")]
		public string AccountLogin { get; set; }
		public string Name { get; set; }
		public List<SurveyPuzzle> SurveyPuzzles { get; set; }
	}
}
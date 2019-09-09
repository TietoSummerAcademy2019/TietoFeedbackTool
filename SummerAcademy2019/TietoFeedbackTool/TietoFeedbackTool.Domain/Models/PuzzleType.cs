using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoFeedbackTool.Domain
{
	public class PuzzleType
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public bool HaveOpenAnswer { get; set; }
		public List<SurveyPuzzle> SurveyPuzzles { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoFeedbackTool.Domain
{
	public class SurveyPuzzle
	{
		[Key]
		public int Id { get; set; }
		public string PuzzleQuestion { get; set; }
		public string Domain { get; set; }
		public bool Enabled { get; set; }
		public List<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
	}
}
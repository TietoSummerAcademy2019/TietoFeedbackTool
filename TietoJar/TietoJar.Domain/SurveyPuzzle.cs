using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoJar.Domain
{
	public class SurveyPuzzle
	{
		[Key]
		public int Id { get; set; }
		public int PuzzleTypeId { get; set; }
		public int SurveyId { get; set; }
		public string PuzzleQuestion { get; set; }
		public int Position { get; set; }
		public List<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		public List<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
	}
}

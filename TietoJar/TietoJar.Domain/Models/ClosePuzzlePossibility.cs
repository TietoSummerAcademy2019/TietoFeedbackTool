using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TietoJar.Domain
{
	public class ClosePuzzlePossibility
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public int SurveyPuzzleId { get; set; }
		public string Answer { get; set; }
		[DefaultValue(1)]
		public int Counter { get; set; }
		public int Position { get; set; }
		public List<ClosePuzzleAnswer> ClosePuzzleAnswers { get; set; }
	}
}
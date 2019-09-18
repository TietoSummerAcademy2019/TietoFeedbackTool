using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoFeedbackTool.Domain
{
	public class Question
	{
		[Key]
		public int Id { get; set; }
		public string QuestionText { get; set; }
		[Required]
		[ForeignKey("Login")]
		public string AccountLogin { get; set; }
		public string Domain { get; set; }
		public bool Enabled { get; set; }
		public string Name { get; set; }
		public bool HasRating { get; set; }
		public bool IsBottom { get; set; }
		public string RatingType { get; set; }
		public List<PuzzleAnswer> PuzzleAnswers { get; set; }
	}
}
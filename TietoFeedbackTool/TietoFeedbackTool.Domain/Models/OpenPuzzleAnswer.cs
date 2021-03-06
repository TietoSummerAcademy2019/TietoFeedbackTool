using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoFeedbackTool.Domain
{
	public class PuzzleAnswer
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public int QuestionId { get; set; }
		[MaxLength(2000, ErrorMessage = "Answer cannot have more than 2000 characters")]
		public string Answer { get; set; }
		public int? Rating { get; set; }
		[Column(TypeName = "Datetime")]
		public DateTime SubmitDate { get; set; }
	}
}
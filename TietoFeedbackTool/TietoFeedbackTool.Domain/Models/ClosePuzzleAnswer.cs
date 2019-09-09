using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace TietoFeedbackTool.Domain
{
	public class ClosePuzzleAnswer
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public int ClosePuzzlePossibilityId { get; set; }
		[Column(TypeName = "Date")]
		public DateTime SubmitDate { get; set; }
	}
}
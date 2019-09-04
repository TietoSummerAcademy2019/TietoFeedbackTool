using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace TietoJar.Domain
{
	public class OpenPuzzleAnswer
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public int SurveyPuzzleId { get; set; }
		[Required]
		[StringLength(2000, ErrorMessage = "Answer cannot have more than 2000 characters")]
		public string Answer { get; set; }
		[Column(TypeName = "Datetime")]
		public DateTime SubmitDate { get; set; }
	}
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TietoJar.Domain
{
	public class OpenPuzzleAnswer
	{
		[Key]
		[ForeignKey("PuzzleTypeId")]
		public int PuzzleId { get; set; }
		[Required]
		[StringLength(2000, ErrorMessage = "Answer cannot have more than 2000 characters")]
		public string Answer { get; set; }
	}
}

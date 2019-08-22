using System.ComponentModel.DataAnnotations.Schema;


namespace TietoJar.Domain
{
	public class ClosePuzzlePossibility
	{
		[ForeignKey("PuzzleTypeId")]
		public int PuzzleId { get; set; }
		public string Answer { get; set; }
		public int Counter { get; set; }
		public int Position { get; set; }
	}
}

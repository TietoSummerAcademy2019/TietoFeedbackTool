using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TietoJar.Domain
{
	public class Survey
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public int AccountId { get; set; }
		public string SurveyKey { get; set; }
		public List<SurveyPuzzle> SurveyPuzzles { get; set; }
	}
}

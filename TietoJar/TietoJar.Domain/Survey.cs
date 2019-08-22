using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TietoJar.Domain
{
	public class Survey
	{
		[Key]
		public int Id { get; set; }
		public string AccountId { get; set; }
		public string Key { get; set; }
		public List<SurveyPuzzle> SurveyPuzzles { get; set; }
	}
}

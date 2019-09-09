using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IClosePuzzlePossibilityRepository : IRepository<ClosePuzzlePossibility>
	{
		ClosePuzzlePossibility GetClosePuzzlePossibility(int SurveyPuzzleId, int position, string answer);
		ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility);
	}
}

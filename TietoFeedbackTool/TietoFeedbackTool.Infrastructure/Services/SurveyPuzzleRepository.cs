using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class SurveyPuzzleRepository : Repository<SurveyPuzzle>, ISurveyPuzzleRepository
	{
		public SurveyPuzzleRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public void UpdateSurveyPuzzle(SurveyPuzzle surveyPuzzle, int id)
		{
			var _surveyPuzzle = _context.SurveyPuzzles.SingleOrDefault(x => x.Id == id);
			_surveyPuzzle.PuzzleQuestion = surveyPuzzle.PuzzleQuestion;
			_surveyPuzzle.Position = surveyPuzzle.Position;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	class ClosePuzzlePossibilityRepository : Repository<ClosePuzzlePossibility>, IClosePuzzlePossibilityRepository
	{
		public ClosePuzzlePossibilityRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public ClosePuzzlePossibility GetClosePuzzlePossibility(int SurveyPuzzleId, int position, string answer)
		{
			return _context.ClosePuzzlePossibilities.Where(x => x.SurveyPuzzleId == SurveyPuzzleId && x.Position == position && x.Answer == answer).SingleOrDefault();
		}

		public ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closepuzzlepossibility)
		{
			ClosePuzzleAnswer closepuzzleanswer = new ClosePuzzleAnswer
			{
				ClosePuzzlePossibilityId = closepuzzlepossibility.Id,
				SubmitDate = DateTime.Now
			};
			_context.ClosePuzzleAnswers.Add(closepuzzleanswer);
			_context.SaveChanges();
			return closepuzzlepossibility;
		}
	}
}

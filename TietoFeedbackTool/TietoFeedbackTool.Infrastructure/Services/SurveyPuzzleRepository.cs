using System;
using System.Collections.Generic;
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

	}
}

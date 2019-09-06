using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class ClosePuzzleAnswerRepository : Repository<ClosePuzzleAnswer>, IClosePuzzleAnswerRepository
	{
		public ClosePuzzleAnswerRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}
		public List<ClosePuzzleAnswer> GetClosePuzzleAnswers(int id)
		{
			return _context.ClosePuzzleAnswers.Where(x => x.ClosePuzzlePossibilityId == id).ToList();
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class PuzzleAnswerRepository : Repository<PuzzleAnswer>, IPuzzleAnswerRepository
	{
		public PuzzleAnswerRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public List<PuzzleAnswer> GetAnserwsByRating(int questionId, int rating)
		{
			List<PuzzleAnswer> cokolwiek = _context.PuzzleAnswers.Where(x => x.QuestionId == questionId).Where(z => z.Rating == rating).ToList();
			return cokolwiek;
		}
	}
}
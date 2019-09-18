using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class PuzzleAnswerRepository : Repository<PuzzleAnswer>, IPuzzleAnswerRepository
	{
		public PuzzleAnswerRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}
	}
}
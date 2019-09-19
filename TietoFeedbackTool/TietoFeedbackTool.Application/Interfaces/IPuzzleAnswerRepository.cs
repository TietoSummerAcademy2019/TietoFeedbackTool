using TietoFeedbackTool.Domain;
using System.Collections.Generic;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IPuzzleAnswerRepository : IRepository<PuzzleAnswer>
	{
        List<PuzzleAnswer> GetAnserwsByRating(int questionId, int rating);
    }
}
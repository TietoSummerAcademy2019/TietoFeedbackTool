using TietoFeedbackTool.Domain;
using System.Collections.Generic;
using System.Collections;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IPuzzleAnswerRepository : IRepository<PuzzleAnswer>
	{
		int GetAnswerRatingRepetitions(int questionId, int rating);
		ArrayList GetAnswerRating(int qustionId);
		List<int> GetAnswerRatingList(int questionId);

	}
}
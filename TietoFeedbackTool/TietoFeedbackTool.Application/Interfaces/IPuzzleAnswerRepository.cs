using TietoFeedbackTool.Domain;
using System.Collections.Generic;
using System.Collections;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IPuzzleAnswerRepository : IRepository<PuzzleAnswer>
	{
		List<int> GetAnserwsByRatingAndQuestionID(int questionId, int rating);
		ArrayList GetAnserwRating(int qustionId);
		List<int> GetAnserwRatingList(int questionId);

	}
}
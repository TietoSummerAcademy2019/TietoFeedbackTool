using TietoFeedbackTool.Domain;
using System.Collections.Generic;
using System.Collections;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IPuzzleAnswerRepository : IRepository<PuzzleAnswer>
	{
		ArrayList GetAnserwsByRatingAndQuestionID(int questionId, int rating);
		ArrayList GetAnserwRating(int qustionId);

	}
}
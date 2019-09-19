using System.Collections;
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

		public ArrayList GetAnserwsByRatingAndQuestionID(int questionId, int rating)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == questionId).Where(z => z.Rating == rating).ToList();
			ArrayList ratingList = new ArrayList();
			ratingList.Add(answers.Count());
			return ratingList;
		}

		public ArrayList GetAnserwRating(int qustionId)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == qustionId).ToList();
			ArrayList ratingList = new ArrayList();
			foreach (PuzzleAnswer rating in answers)
			{
				ratingList.Add(rating.Rating);
			}
			return ratingList;
		}
	}
}
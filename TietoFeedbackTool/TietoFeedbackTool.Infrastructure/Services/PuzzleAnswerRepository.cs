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

		public List<int> GetAnserwsByRatingAndQuestionID(int questionId, int rating)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == questionId).Where(z => z.Rating == rating).ToList();
			List<int> ratingList = new List<int>
			{
				answers.Count()
			};
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

		public List<int> GetAnserwRatingList(int questionId)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == questionId).ToList();
			List<int> ratingList = new List<int>();
			for (int i = 1; i <= 5; i++)
			{
				int tmp = answers.Where(x => x.Rating == i).Count();
				ratingList.Add(tmp);
			}
			return ratingList;
		}
	}
}
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

		public int GetAnswerRatingRepetitions(int questionId, int rating)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == questionId).Where(z => z.Rating == rating).ToList();
			int ratingAnswer = answers.Count();
			return ratingAnswer;
		}

		public ArrayList GetAnswerRating(int qustionId)
		{
			List<PuzzleAnswer> answers = _context.PuzzleAnswers.Where(x => x.QuestionId == qustionId).ToList();
			ArrayList ratingList = new ArrayList();
			foreach (PuzzleAnswer rating in answers)
			{
				ratingList.Add(rating.Rating);
			}
			return ratingList;
		}

		public List<int> GetAnswerRatingList(int questionId)
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	/// <summary>
	/// Repository contains handlig method of PuzzleAnswer model.
	/// </summary>
	public class PuzzleAnswerRepository : Repository<PuzzleAnswer>, IPuzzleAnswerRepository
	{
		public PuzzleAnswerRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		/// <summary>
		/// Get number of repetitions of given rating related to specific question
		/// </summary>
		/// <param name="questionId">Question Id</param>
		/// <param name="rating">PuzzleAnswer rating</param>
		/// <returns>Number of repetitions rating of specific question</returns>
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

		/// <summary>
		/// Get list of rating related to specific question.
		/// Index 0 = number of 1 rating
		/// Index 1 = number of 2 rating ... and so on
		/// </summary>
		/// <param name="questionId">Question Id</param>
		/// <returns>List of rating</returns>
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
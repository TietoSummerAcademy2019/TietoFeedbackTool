using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	/// <summary>
	/// Repository contains handlig method of Question model.
	/// </summary>
	public class QuestionRepository : Repository<Question>, IQuestionRepository
	{
		public QuestionRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		/// <summary>
		/// Update specific question.
		/// Available fields for updating: QuestionTest, Domain, Enabled, IsBottom
		/// </summary>
		/// <param name="question">Question: QuestionTest, Domain, Enabled, IsBottom</param>
		/// <param name="id">Question Id</param>
		public void UpdateQuestion(Question question, int id)
		{
			var _question = _context.Question.SingleOrDefault(x => x.Id == id);
			_question.QuestionText = question.QuestionText;
			_question.Domain = question.Domain;
			_question.Enabled = question.Enabled;
			_question.IsBottom = question.IsBottom;
			_question.HasRating = question.HasRating;
			_question.RatingType = question.RatingType;
		}

		/// <summary>
		/// Modified method from basic repository.
		/// Get specific question and all related answers to it.
		/// </summary>
		/// <param name="id">Question Id</param>
		/// <returns>Specyfic Question</returns>
		public new Question Get(int id)
		{
			return _context.Question.Include(x => x.PuzzleAnswers).Where(x => x.Id == id).SingleOrDefault();
		}

		/// <summary>
		/// Check if there is question with such domain in database
		/// </summary>
		/// <param name="domain">Question domain</param>
		/// <returns>True if find any question with given domain</returns>
		public bool IsThereQuestionWithDomain(string domain)
		{
			return _context.Question.Any(x => x.Domain == domain);
		}

		/// <summary>
		/// Get list of question related to specific domain
		/// </summary>
		/// <param name="login">Account login</param>
		/// <param name="domain">Question domain</param>
		/// <returns>List of question related to specific domian</returns>
		public List<Question> GetQuestionsByDomain(string login, string domain)
		{
			var account = _context.Accounts.Include(x => x.Questions).ThenInclude(questions => questions.PuzzleAnswers).Where(x => x.Login == login).SingleOrDefault();

			if (account.Questions.Any(x => x.Domain == domain))
			{
				return account.Questions.Where(x => x.Domain == domain).ToList();
			}
			else
			{
				return null;
			}
		}
	}
}

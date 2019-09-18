using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class QuestionRepository : Repository<Question>, IQuestionRepository
	{
		public QuestionRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public void UpdateQuestion(Question question, int id)
		{
			var _question = _context.Question.SingleOrDefault(x => x.Id == id);
			_question.QuestionText = question.QuestionText;
			_question.Domain = question.Domain;
			_question.Enabled = question.Enabled;
		}

		public new Question Get(int id)
		{
			return _context.Question.Include(x => x.PuzzleAnswers).Where(x => x.Id == id).SingleOrDefault();
		}
	}
}

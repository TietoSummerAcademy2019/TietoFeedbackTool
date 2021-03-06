using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IQuestionRepository : IRepository<Question>
	{
		void UpdateQuestion(Question question, int id);
		new Question Get(int id);

		bool IsThereQuestionWithDomain(string domain);
		List<Question> GetQuestionsByDomain(string login, string domain);
	}
}

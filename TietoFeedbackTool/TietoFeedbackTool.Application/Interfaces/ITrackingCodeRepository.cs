using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITrackingCodeRepository : IRepository<Account>
	{
		new Account GetByString(string surveyKey);

		List<Question> GetSurveyByDomain(string surveyKey, string domain);

		string GetSurveyHtmlWithDomain(string key, string domain, string path);
		string GetDummySurveyHtml(string path, Question question);
		string GetDummyScript(string path, Question question);

		string GetSurveyHtml(string key, string path);

		string GetSurveyCSS(string path);

		string GetScript(string surveyKey, string path);
	}
}
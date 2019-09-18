using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITrackingCodeRepository : IRepository<Account>
	{
		new Account GetByString(string surveyKey);

		List<Question> GetSurveyByDomain(string surveyKey, string domain);

		List<Question> GetQuestionsWithAnswersByDomaiName(string doaminName);

		string GetDomainByDomainName(string domainName);

		string GetSurveyHtmlWithDomain(string key, string domain, string path);
		string GetRatingTypeImg(string ratingType);

		string GetSurveyHtml(string key, string path);

		string GetSurveyCSS(string path);

		string GetScript(string surveyKey, string path);
	}
}
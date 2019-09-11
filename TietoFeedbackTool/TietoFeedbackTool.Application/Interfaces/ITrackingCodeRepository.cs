using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITrackingCodeRepository : IRepository<Account>
	{
		Account GetSurvey(string surveyKey);
		List<Question> GetSurveyByDomain(string surveyKey, string domain);
		string GetSurveyHtmlWithDomain(string key, string domain);
		string GetSurveyHtml(string key);
		string GetSurveyCSS();
		string GetScript(string surveyKey);
	}
}

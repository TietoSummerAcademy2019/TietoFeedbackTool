using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITrackingCodeRepository : IRepository<Account>
	{
		new Account GetByString(string surveyKey);
		List<Question> GetSurveyByDomain(string surveyKey, string domain);
		string GetSurveyHtmlWithDomain(string key, string domain);
		string GetSurveyHtml(string key, string path);
		string GetSurveyCSS();
		string GetScript(string surveyKey);
	}
}

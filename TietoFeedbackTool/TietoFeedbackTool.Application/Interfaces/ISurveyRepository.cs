using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
		//Survey
        Survey GetSurvey(string surveyKey);
		Account GetSurveysWithQuestions(string login);
		void UpdateSurvey(Survey survey, string surveyKey);
		string GetSurveyHtml(string key);
		string GetSurveySCSS();
		List<string> GetDomains();
	}
}
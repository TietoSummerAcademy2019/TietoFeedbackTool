using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
		//Survey
        Survey GetSurvey(string surveyKey);
		Survey GetSurveyByDomain(string surveyKey, string domain);
		Account GetSurveysWithQuestions(string login);
		void UpdateSurvey(Survey survey, string surveyKey);
	}
}
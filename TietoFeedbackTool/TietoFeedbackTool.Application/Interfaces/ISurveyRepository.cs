using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
		//Survey
		Survey GetSurveyByDomain(string surveyKey, string domain);
		void UpdateSurvey(Survey survey, string surveyKey);
	}
}
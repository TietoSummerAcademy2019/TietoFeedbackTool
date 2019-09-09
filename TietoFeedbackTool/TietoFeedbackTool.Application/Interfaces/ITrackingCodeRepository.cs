using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITrackingCodeRepository : IRepository<Survey>
	{
		Survey GetSurvey(string surveyKey);
		string GetSurveyHtml(string key);
		string GetSurveySCSS();
	}
}

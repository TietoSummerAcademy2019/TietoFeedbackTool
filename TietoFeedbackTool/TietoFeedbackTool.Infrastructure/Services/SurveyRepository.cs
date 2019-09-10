using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;
using Microsoft.EntityFrameworkCore;

namespace TietoFeedbackTool.Infrastructure.Services
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
		public SurveyRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public Survey GetSurveyByDomain(string surveyKey, string domain)
		{
			return _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey && x.Domain == domain);
		}

		public void UpdateSurvey(Survey survey, string surveyKey)
		{
			var _survey = _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey);
			_survey.Name = survey.Name;
		}
	}
 }
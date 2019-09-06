using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoFeedbackTool.Infrastructure.Services
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
		public SurveyRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}
        public Survey GetSurvey(string surveyKey)
        {
            return _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey);
        }

		public Account GetSurveysWithQuestions(string login)
		{
			Account surveysToRet = _context.Accounts.Where(x => x.Login == login).Include("Surveys.SurveyPuzzles.OpenPuzzleAnswers").SingleOrDefault();

			return surveysToRet;
		}
		public void UpdateSurvey(Survey survey, string surveyKey)
		{
			var _survey = _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey);
			_survey.Name = survey.Name;
		}
	}
 }
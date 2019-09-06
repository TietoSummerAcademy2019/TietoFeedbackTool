using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

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

		public string GetSurveyHtml(string key)
		{
			var survey = GetSurvey(key);

			if (survey != null)
			{
				string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				return LoadFile(scriptPath);
			}
			return null;
		}

		public string GetSurveySCSS()
		{
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.scss";
			return LoadFile(scriptPath);
		}

		public string LoadFile(string path)
		{
			if (File.Exists(path))
			{
				using (StreamReader sr = new StreamReader(path))
				{
					return sr.ReadToEnd();
				}
			}

			return null;
		}

		public List<string> GetDomains()
		{
			var surveys = _context.Surveys.ToList();
			List<string> domains = surveys.Select(item => item.Domain).ToList();
			return domains;
		}

		public string GetDomain(string domain)
		{
			var _domain = _context.Surveys.SingleOrDefault(x => x.Domain == domain);
			return _domain.ToString();
		}
	}
 }
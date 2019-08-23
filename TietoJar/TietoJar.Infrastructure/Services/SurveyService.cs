using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoJar.Application.Interfaces;
using TietoJar.Persistence;
using TietoJar.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoJar.Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        public readonly TietoJarContext _context;

        public SurveyService(TietoJarContext context)
        {
            _context = context;
        }

        public Survey AddSurvey(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return survey;
        }

        public void DeleteSurvey(int id)
        {
            var survey = _context.Surveys.Where(x => x.Id == id).FirstOrDefault();
            _context.Surveys.Remove(survey);
            _context.SaveChanges();
        }

        public Survey GetSurvey(int id)
        {
			return _context.Surveys.SingleOrDefault(x => x.Id == id);
        }

        public List<Survey> GetSurveys()
        {
            var survey = _context.Surveys.ToList();
            return survey;
        }

        public Survey UpdateSurvey(int id, Survey survey)
        {
			var _survey = _context.Surveys.SingleOrDefault(x => x.Id == id);
			
			_survey.Name = survey.Name;
			_survey.SurveyKey = survey.SurveyKey;
			_survey.AccountLogin = survey.AccountLogin;
			_context.SaveChanges();
			return survey;
		}
		public SurveyPuzzle AddSurveyPuzzle(SurveyPuzzle surveyPuzzle)
		{
			_context.SurveyPuzzles.Add(surveyPuzzle);
			_context.SaveChanges();
			return surveyPuzzle;
		}
		public List<SurveyPuzzle> GetSurveyPuzzles()
		{
			var surveyPuzzle = _context.SurveyPuzzles.ToList();
			return surveyPuzzle;
		}
	}
 }
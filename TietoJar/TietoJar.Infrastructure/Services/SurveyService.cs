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
			var survey = _context.Surveys.SingleOrDefault(x => x.Id == id);
			if (survey != null)
			{
				return _context.Surveys.SingleOrDefault(x => x.Id == id);
			}
			else
			{
				throw new Exception("Not found");
			}
        }

        public List<Survey> GetSurveys()
        {
            var survey = _context.Surveys.ToList();
            return survey;
        }

        public Survey UpdateSurvey(int id, Survey survey)
        {
			var _survey = _context.Surveys.SingleOrDefault(x => x.Id == id);
			if (_survey == null)
			{
				throw new Exception("Not found");
			}
			else
			{
				_survey.SurveyKey = survey.SurveyKey;
				_survey.AccountId = survey.AccountId;
				_context.SaveChanges();
				return survey;
			}
		}
	}
 }
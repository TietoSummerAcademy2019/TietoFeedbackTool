using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoJar.Application.Services;
using TietoJar.Domain;
using TietoJar.Persistence;

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

		public Survey DeleteSurvey(int id)
		{
			Survey survey = _context.Surveys.Where(x => x.Id == id).FirstOrDefault();
			_context.Surveys.Remove(survey);
			_context.SaveChanges();
			return survey;
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

		public Survey UpdateSurvey(Survey survey)
		{
			_context.Surveys.Update(survey);
			_context.SaveChanges();
			return survey;
		}
	}
}

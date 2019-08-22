using System;
using System.Collections.Generic;
using System.Text;
using TietoJar.Domain;


namespace TietoJar.Application.Services
{
	public interface ISurveyService
	{
		List<Survey> GetSurveys();
		Survey AddSurvey(Survey survey);
		Survey GetSurvey(int id);
		Survey UpdateSurvey(Survey survey);
		Survey DeleteSurvey(int id);
	}
}

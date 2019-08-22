using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Persistence;
using TietoJar.Application;
using TietoJar.Domain;
using TietoJar.Application.Interfaces;
using TietoJar.Application.Services;

namespace TietoJar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SurveyController : Controller
    {
		public readonly ISurveyService _surveyService;
		public SurveyController(ISurveyService surveyService)

		{
			_surveyService = surveyService;
		}
		//SURVEYS CRUD
		[HttpPost]
		public Survey AddSurvey([FromBody]Survey survey)
		{
			return _surveyService.AddSurvey(survey);
		}
		[HttpGet]
		public List<Survey> GetSurveys()
		{
			return _surveyService.GetSurveys();
		}
		[HttpGet("{Id}")]
		public Survey GetSurvey(int id)
		{
			return _surveyService.GetSurvey(id);
		}
		[HttpPut]
		public Survey UpdateSurvey([FromBody]Survey survey)
		{
			return _surveyService.UpdateSurvey(survey);
		}
		[HttpDelete("{Id}")]
		public Survey DeleteSurvey(int id)
		{
			return _surveyService.DeleteSurvey(id);
		}
    }
}

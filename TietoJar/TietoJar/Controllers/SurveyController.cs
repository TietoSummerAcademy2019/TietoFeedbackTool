using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;

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

        [HttpPut("{Id}")]
		public Survey UpdateSurvey(int id, [FromBody]Survey survey)
		{
			return _surveyService.UpdateSurvey(id, survey);
		}

		[HttpDelete("{Id}")]
		public NoContentResult DeleteSurvey(int id)
		{
			_surveyService.DeleteSurvey(id);
			return NoContent();
		}
	}
}

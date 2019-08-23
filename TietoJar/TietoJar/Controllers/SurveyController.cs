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
        public ActionResult<List<Survey>> GetSurveys()
        {
			var survey = _surveyService.GetSurveys();

			if (survey.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return _surveyService.GetSurveys();
			}
        }

        [HttpPost("questions")]
        public SurveyPuzzle AddSurveyPuzzle([FromBody]SurveyPuzzle surveyPuzzle)
        {
            return _surveyService.AddSurveyPuzzle(surveyPuzzle);
        }

        [HttpGet("questions")]
        public ActionResult<List<SurveyPuzzle>> GetSurveyPuzzles()
        {
			var survey = _surveyService.GetSurveyPuzzles();

			if (survey.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return _surveyService.GetSurveyPuzzles();
			}
        }

        [HttpGet("{Id}")]
        public ActionResult<Survey> GetSurvey(int id)
        {
            var survey = _surveyService.GetSurvey(id);

            if (survey == null)
			{
                return NotFound();
            }
            else
            {
                return survey;
            }
        }

        [HttpPut("{Id}")]
		public ActionResult<Survey> UpdateSurvey(int id, [FromBody]Survey survey)
		{
			var _survey = _surveyService.GetSurvey(id);

			if (_survey == null)
			{
				return NotFound();
			}
			else
			{
				return _surveyService.UpdateSurvey(id, survey);
			}
		}

		[HttpDelete("{Id}")]
		public NoContentResult DeleteSurvey(int id)
		{
			_surveyService.DeleteSurvey(id);
			return NoContent();
		}
	}
}

using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SurveyController : Controller
	{
		public readonly ISurveyService _surveyService;
		public readonly IAccountService _accountService;

		public SurveyController(ISurveyService surveyService, IAccountService accountService)
		{
			_surveyService = surveyService;
			_accountService = accountService;
		}

		//SURVEYS CRUD
		//Survey
		[HttpPost]
        public ActionResult<Survey> AddSurvey([FromBody]Survey survey)
        {
			var account = _accountService.GetAccount(survey.AccountLogin);
			var _survey = _surveyService.GetSurvey(survey.SurveyKey);
			if (account == null)
			{
				return NotFound("Cant add Survey to not existing Account");
			}
			else if (_survey == null)
			{
				return _surveyService.AddSurvey(survey);
			}
			else
			{
				return Conflict("Survey key already exist");
			}
        }

        [HttpGet]
        public ActionResult<List<Survey>> GetSurveys()
        {
			var survey = _surveyService.GetSurveys();
			if (survey.Count == 0)
			{
				return NotFound("No Surveys Found, try adding Survey");
			}
			else
			{
				return _surveyService.GetSurveys();
			}
        }

		[HttpGet("{SurveyKey}")]
		public ActionResult<Survey> GetSurvey(string surveyKey)
		{
			var survey = _surveyService.GetSurvey(surveyKey);
			if (survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return survey;
			}
		}

		[HttpPut("{SurveyKey}")]
		public ActionResult<Survey> UpdateSurvey(string surveyKey, [FromBody]Survey survey)
		{
			var _survey = _surveyService.GetSurvey(surveyKey);
			if (_survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return _surveyService.UpdateSurvey(surveyKey, survey);
			}
		}

		[HttpDelete("{SurveyKey}")]
		public ActionResult DeleteSurvey(string surveyKey)
		{
			var _survey = _surveyService.GetSurvey(surveyKey);
			if (_survey == null)
			{
				return NotFound("Cant find survey with this Key");
			}
			else
			{
				_surveyService.DeleteSurvey(surveyKey);
				return NoContent();
			}
		}

		//SurveyPuzzle
		[HttpPost("questions")]
        public ActionResult<SurveyPuzzle> AddSurveyPuzzle([FromBody]SurveyPuzzle surveyPuzzle)
        {
			var survey = _surveyService.GetSurvey(surveyPuzzle.SurveyKey);
			var puzzleType = _surveyService.GetPuzzleType(surveyPuzzle.PuzzleTypeId);
			if (survey == null)
			{
				return NotFound("Cant found Survey");
			}
			else if (puzzleType == null)
			{
				return NotFound("Cant found Type of question");
			}
			else
			{
				return _surveyService.AddSurveyPuzzle(surveyPuzzle);
			}
		}

        [HttpGet("questions")]
        public ActionResult<List<SurveyPuzzle>> GetSurveyPuzzles()
        {
			var survey = _surveyService.GetSurveyPuzzles();
			if (survey.Count == 0)
			{
				return NotFound("No questions found, try adding a question");
			}
			else
			{
				return _surveyService.GetSurveyPuzzles();
			}
        }

		[HttpGet("questions/{Id}")]
		public ActionResult<SurveyPuzzle> GetSurveyPuzzle(int id)
		{
			var survey = _surveyService.GetSurveyPuzzle(id);
			if (survey == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				return survey;
			}
		}

		[HttpPut("questions/{Id}")]
		public ActionResult<SurveyPuzzle> UpdateSurveyPuzzle(int id, [FromBody]SurveyPuzzle surveyPuzzle)
		{
			var _survey = _surveyService.GetSurveyPuzzle(id);
			if (_survey == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				return _surveyService.UpdateSurveyPuzzle(id, surveyPuzzle);
			}
		}

		[HttpDelete("questions/{Id}")]
		public ActionResult DeleteSurveyPuzzle(int id)
		{
			var _survey = _surveyService.GetSurveyPuzzle(id);
			if (_survey == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_surveyService.DeleteSurveyPuzzle(id);
				return NoContent();
			}			
		}

		//PuzzleType
		[HttpPost("type")]
		public PuzzleType AddPuzzleType([FromBody]PuzzleType puzzleType)
		{
			return _surveyService.AddPuzzleType(puzzleType);
		}

		[HttpGet("type")]
		public ActionResult<List<PuzzleType>> GetPuzzleTypes()
		{
			var puzzle = _surveyService.GetPuzzleTypes();
			if (puzzle.Count == 0)
			{
				return NotFound("No PuzzleType found, try adding a PuzzleType");
			}
			else
			{
				return _surveyService.GetPuzzleTypes();
			}
		}

		[HttpGet("type/{Id}")]
		public ActionResult<PuzzleType> GetPuzzleType(int id)
		{
			var survey = _surveyService.GetPuzzleType(id);
			if (survey == null)
			{
				return NotFound("Cant find PuzzleType with this id.");
			}
			else
			{
				return survey;
			}
		}

		[HttpPut("type/{Id}")]
		public ActionResult<PuzzleType> UpdatePuzzleType(int id, PuzzleType puzzleType)
		{
			var _survey = _surveyService.GetPuzzleType(id);
			if (_survey == null)
			{
				return NotFound("Cant find PuzzleType with this id.");
			}
			else
			{
				return _surveyService.UpdatePuzzleType(id, puzzleType);
			}
		}

		[HttpDelete("type/{Id}")]
		public ActionResult DeletePuzzleType(int id)
		{
			var _survey = _surveyService.GetPuzzleType(id);
			if (_survey == null)
			{
				return NotFound("Cant find PuzzleType with this id.");
			}
			else
			{
				_surveyService.DeletePuzzleType(id);
				return NoContent();
			}
		}

		[HttpGet("surveywithq/{login}")]
		public ActionResult<Account> GetSurveysWithQuestions(string login)
		{
			var _survey =  _surveyService.GetSurveysWithQuestions(login);
			if (_survey == null)
			{
				return NotFound("Account not found");
			}
			else
			{
				return _survey;
			}			
		}

		[HttpGet("getscript")]
		[Produces("text/js")]
		public ActionResult<Account> GetSurveyScript()
		{
			string userSideScript = "";
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/scripts/userSideScript.js";
			using (StreamReader sr = new StreamReader(scriptPath))
			{
				userSideScript = sr.ReadToEnd();
			}

			return Content(userSideScript, "text/js");
		}
		[HttpGet("getstyle")]
		[Produces("text/css")]
		public ActionResult<Account> GetSurveySCSS()
		{
			string userSideSCSS = "";
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.scss";
			using (StreamReader sr = new StreamReader(scriptPath))
			{
				userSideSCSS = sr.ReadToEnd();
			}

			return Content(userSideSCSS, "text/css");
		}
		[HttpGet("getsurvey/{key}")]
		[Produces("text/html")]
		public ActionResult<Account> GetSurveyHTML(string key)
		{
			string HTMLContent = "";
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
			using (StreamReader sr = new StreamReader(scriptPath))
			{
				HTMLContent = sr.ReadToEnd();
			}

			return Content(HTMLContent, "text/html");
		}
		[HttpPost("postanswer")]
		public ActionResult<Account> Answerhandler([FromBody]OpenPuzzleAnswer answer)
		{
			return NotFound("not implemented");
		}
	}
}
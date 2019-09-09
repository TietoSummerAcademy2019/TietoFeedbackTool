using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SurveyController : Controller
	{
		public readonly IUnitOfWork _unitOfWork;

		public SurveyController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		//SURVEYS CRUD
		//Survey
		[HttpPost]
		public ActionResult AddSurvey([FromBody]Survey survey)
		{
			var account = _unitOfWork.Account.GetAccount(survey.AccountLogin);
			var _survey = _unitOfWork.Survey.GetSurvey(survey.SurveyKey);
			if (account == null)
			{
				return NotFound("Cant add Survey to not existing Account");
			}
			else if (_survey == null)
			{
				_unitOfWork.Survey.Add(survey);
				_unitOfWork.Complete();
				return Ok(survey);
			}
			else
			{
				return Conflict("Survey key already exist");
			}
		}

		[HttpGet]
		public ActionResult<IEnumerable<Survey>> GetSurveys()
		{
			var survey = _unitOfWork.Survey.GetAll();
			if (survey == null)
			{
				return NotFound("No Surveys Found, try adding Survey");
			}
			else
			{
				return _unitOfWork.Survey.GetAll().ToList();
			}
		}

		[HttpGet("{SurveyKey}")]
		public ActionResult<Survey> GetSurvey(string surveyKey)
		{
			var survey = _unitOfWork.Survey.GetSurvey(surveyKey);
			if (survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return survey;
			}
		}

		[HttpGet("{SurveyKey}/{Domain}")]
		public ActionResult<Survey> GetSurveyByDomain(string surveyKey, string domain)
		{
			var survey = _unitOfWork.Survey.GetSurveyByDomain(surveyKey, domain);
			if (survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return Ok(survey);
			}
		}

		[HttpPut("{SurveyKey}")]
		public ActionResult<Survey> UpdateSurvey(string surveyKey, [FromBody]Survey survey)
		{
			var _survey = _unitOfWork.Survey.GetSurvey(surveyKey);
			if (_survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				_unitOfWork.Survey.UpdateSurvey(survey, surveyKey);
				_unitOfWork.Complete();
				return Ok(survey);
			}
		}

		[HttpDelete("{SurveyKey}")]
		public ActionResult DeleteSurvey(string surveyKey)
		{
			var _survey = _unitOfWork.Survey.GetSurvey(surveyKey);
			if (_survey == null)
			{
				return NotFound("Cant find survey with this Key");
			}
			else
			{
				_unitOfWork.Survey.Remove(_survey);
				_unitOfWork.Complete();
				return NoContent();
			}
		}

		//SurveyPuzzle
		[HttpPost("questions")]
		public ActionResult AddSurveyPuzzle([FromBody]SurveyPuzzle surveyPuzzle)
		{
			var survey = _unitOfWork.Survey.GetSurvey(surveyPuzzle.SurveyKey);
			var puzzleType = _unitOfWork.PuzzleType.Get(surveyPuzzle.PuzzleTypeId);
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
				_unitOfWork.SurveyPuzzle.Add(surveyPuzzle);
				_unitOfWork.Complete();
				return Ok(surveyPuzzle);
			}
		}

		[HttpGet("questions")]
		public ActionResult<IEnumerable<SurveyPuzzle>> GetSurveyPuzzles()
		{
			var survey = _unitOfWork.SurveyPuzzle.GetAll();
			if (survey == null)
			{
				return NotFound("No questions found, try adding a question");
			}
			else
			{
				return _unitOfWork.SurveyPuzzle.GetAll().ToList();
			}
		}

		[HttpGet("questions/{Id}")]
		public ActionResult<SurveyPuzzle> GetSurveyPuzzle(int id)
		{
			var survey = _unitOfWork.SurveyPuzzle.Get(id);
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
			var _survey = _unitOfWork.SurveyPuzzle.Get(id);
			if (_survey == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_unitOfWork.SurveyPuzzle.UpdateSurveyPuzzle(surveyPuzzle, id);
				_unitOfWork.Complete();
				return Ok(surveyPuzzle);
			}
		}

		[HttpDelete("questions/{Id}")]
		public ActionResult DeleteSurveyPuzzle(int id)
		{
			var _survey = _unitOfWork.SurveyPuzzle.Get(id);
			if (_survey == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_unitOfWork.SurveyPuzzle.Remove(_survey);
				return NoContent();
			}
		}

		//PuzzleType
		[HttpPost("type")]
		public ActionResult AddPuzzleType([FromBody]PuzzleType puzzleType)
		{
			_unitOfWork.PuzzleType.Add(puzzleType);
			_unitOfWork.Complete();
			return Ok(puzzleType);
		}

		[HttpGet("type")]
		public ActionResult<IEnumerable<PuzzleType>> GetPuzzleTypes()
		{
			var puzzle = _unitOfWork.PuzzleType.GetAll();
			if (puzzle == null)
			{
				return NotFound("No PuzzleType found, try adding a PuzzleType");
			}
			else
			{
				return _unitOfWork.PuzzleType.GetAll().ToList();
			}
		}

		[HttpGet("type/{Id}")]
		public ActionResult<PuzzleType> GetPuzzleType(int id)
		{
			var survey = _unitOfWork.PuzzleType.Get(id);
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
			var _survey = _unitOfWork.PuzzleType.Get(id);
			if (_survey == null)
			{
				return NotFound("Cant find PuzzleType with this id.");
			}
			else
			{
				_unitOfWork.PuzzleType.UpdatePuzzleType(puzzleType, id);
				_unitOfWork.Complete();
				return Ok(puzzleType);
			}
		}

		[HttpDelete("type/{Id}")]
		public ActionResult DeletePuzzleType(int id)
		{
			var _survey = _unitOfWork.PuzzleType.Get(id);
			if (_survey == null)
			{
				return NotFound("Cant find PuzzleType with this id.");
			}
			else
			{
				_unitOfWork.PuzzleType.Remove(_survey);
				_unitOfWork.Complete();
				return NoContent();
			}
		}

		[HttpGet("surveywithq/{login}")]
		public ActionResult<Account> GetSurveysWithQuestions(string login)
		{
			var _survey = _unitOfWork.Survey.GetSurveysWithQuestions(login);
			if (_survey == null)
			{
				return NotFound("Account not found");
			}
			else
			{
				return _survey;
			}
		}

		[HttpGet("getscript/{surveyKey}")]
		[Produces("text/js")]
		public ActionResult<Account> GetSurveyScript(string surveyKey)
		{
			var userSideScript = _unitOfWork.TrackingCode.GetScript(surveyKey);
			if (userSideScript == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return Content(userSideScript, "text/js");
			}
		}
		[HttpGet("getstyle")]
		[Produces("text/css")]
		public ActionResult<Account> GetSurveyCSS()
		{
			var surveyCSS = _unitOfWork.TrackingCode.GetSurveyCSS();
			if (surveyCSS == null)
			{
				return NotFound("Cant find Survey style file");
			}
			else
			{
				return Content(surveyCSS, "text/css");
			}
		}
		[HttpGet("getsurvey/{key}/{domain}")]
		[Produces("text/html")]
		public ActionResult<Account> GetSurveyHTMLWithDomain(string key, string domain)
		{
			var surveyHTML = _unitOfWork.TrackingCode.GetSurveyHtmlWithDomain(key, domain);
			if (surveyHTML == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return Content(surveyHTML, "text/html");
			}
		}

		[HttpGet("getsurvey/{key}")]
		[Produces("text/html")]
		public ActionResult<Account> GetSurveyHTML(string key)
		{
			var surveyHTML = _unitOfWork.TrackingCode.GetSurveyHtml(key);
			if (surveyHTML == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return Content(surveyHTML, "text/html");
			}
		}
	}
}
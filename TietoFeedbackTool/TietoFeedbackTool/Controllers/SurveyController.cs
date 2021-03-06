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

		/// <summary>
		/// Get list of question related to specific key and domain
		/// </summary>
		/// <param name="key">Account.QuestionsKey</param>
		/// <param name="domain">Qestion.Domain</param>
		/// <returns>List of question related to specific key and domain</returns>
		/// <response code="200">Returns list of question :D</response>
		[HttpGet("{key}/{domain}")]
		public ActionResult<Question> GetQuestions(string key, string domain)
		{
			var checkAccount = _unitOfWork.Account.Find(x => x.QuestionsKey == key);
			var checkDomain = _unitOfWork.Question.Find(x => x.Domain == domain);
			if (checkAccount.Count() == 0 || checkDomain.Count() == 0)
			{
				return NotFound("Your key or domain is invalid");
			}
			else
			{
				var questions = _unitOfWork.TrackingCode.GetSurveyByDomain(key, domain);
				return Ok(questions);
			}
		}

		/// <summary>
		/// Get list of question related to specific login and domain
		/// </summary>
		/// <param name="login">Account.Login</param>
		/// <param name="domain">Qestion.Domain</param>
		/// <returns>List of question related to specific login and domain</returns>
		/// <response code="200">Returns list of question :D</response>
		[HttpGet("questionsbydomain/{login}/{domain}")]
		public ActionResult<List<Question>> GetQuestionsByDomain(string login, string domain)
		{
			var account = _unitOfWork.Account.GetByString(login);
			if (account == null)
			{
				return NotFound("There is no account with that login");
			}
			else
			{
				var questions = _unitOfWork.Question.GetQuestionsByDomain(login, domain);
				if (questions == null)
				{
					return NotFound("There is no domain like that in that account");
				}
				else
				{
					return Ok(questions);
				}
			}
		}

		/// <summary>
		/// Add a new question
		/// </summary>
		/// <param name="question">Question object</param>
		/// <returns>Newly created question</returns>
		/// <response code="200">Returns newly created question</response>
		[HttpPost("questions")]
		public ActionResult AddQuestion([FromBody]Question question)
		{
			var account = _unitOfWork.Account.GetByString(question.AccountLogin);
			if (account == null)
			{
				return NotFound("There is no account with that login");
			}
			else
			{
				_unitOfWork.Question.Add(question);
				_unitOfWork.Complete();
				return Ok(question);
			}
		}

		/// <summary>
		/// Get list of all questions
		/// </summary>
		/// <returns>List of all questions</returns>
		/// <response code="200">Returns list of question</response>
		[HttpGet("questions")]
		public ActionResult<IEnumerable<Question>> GetQuestions()
		{
			var question = _unitOfWork.Question.GetAll().ToList();
			if (question == null)
			{
				return NotFound("No questions found, try adding a question");
			}
			else
			{
				return Ok(question);
			}
		}

		/// <summary>
		/// Get specific question
		/// </summary>
		/// <param name="id">Question.Id</param>
		/// <returns>Specific question</returns>
		/// <response code="200">Returns specific question</response>
		[HttpGet("questions/{id}")]
		public ActionResult<Question> GetQuestion(int id)
		{
			var question = _unitOfWork.Question.Get(id);
			if (question == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				return Ok(question);
			}
		}

		/// <summary>
		/// Edit specific question
		/// </summary>
		/// <param name="id">Question.Id</param>
		/// <param name="question">Question object</param>
		/// <returns>Edited question</returns>
		/// <response code="200">Returns edited question</response>
		[HttpPut("questions/{id}")]
		public ActionResult<Question> UpdateQuestion(int id, [FromBody]Question question)
		{
			var questionToRet = _unitOfWork.Question.Get(id);
			if (questionToRet == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_unitOfWork.Question.UpdateQuestion(question, id);
				_unitOfWork.Complete();
				return Ok(question);
			}
		}

		/// <summary>
		/// Set selected question enable state
		/// </summary>
		/// <param name="id">Question.Id</param>
		/// <param name="isEnabled">Question.IsEnabled</param>
		/// <returns>Enabled/disabled question</returns>
		/// <response code="200">Returns enabled/disabled question</response>
		[HttpPut("questions/enable/{id}/{isEnabled}")]
		public ActionResult<Question> EnableQuestion(int id, bool isEnabled)
		{
			var questionToRet = _unitOfWork.Question.Get(id);
			if (questionToRet == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				questionToRet.Enabled = isEnabled;
				_unitOfWork.Question.UpdateQuestion(questionToRet, id);
				_unitOfWork.Complete();
				return Ok(questionToRet);
			}
		}

		/// <summary>
		/// Delete specific question
		/// </summary>
		/// <param name="id">Question.Id</param>
		/// <returns>No content</returns>
		/// <response code="204">Returns no content</response>
		[HttpDelete("questions/{id}")]
		public ActionResult DeleteQuestion(int id)
		{
			var question = _unitOfWork.Question.Get(id);
			if (question == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_unitOfWork.Question.Remove(question);
				_unitOfWork.Complete();
				return NoContent();
			}
		}

		/// <summary>
		/// Delete all questions in domain
		/// </summary>
		/// <param name="login">account login</param>
		/// <param name="domain">domain in which you want to remove question in</param>
		/// <returns>No content</returns>
		/// <response code="204">Returns no content</response>
		[HttpDelete("questions/{login}/{domain}")]
		public ActionResult DeleteQuestionsWithDomain(string login, string domain)
		{
			var questions = _unitOfWork.Question.GetQuestionsByDomain(login, domain);
			if (questions == null)
			{
				return NotFound("Cannot find questions in this domain");
			}
			else
			{
				_unitOfWork.Question.RemoveRange(questions);
				_unitOfWork.Complete();
				return NoContent();
			}
		}

		/// <summary>
		/// Get script for installing feedback tool for specific key
		/// </summary>
		/// <param name="key">Account.QuestionsKey</param>
		/// <returns>Installation script</returns>
		/// <response code="200">Returns installation script</response>
		[HttpGet("getscript/{key}")]
		[Produces("text/js")]
		public ActionResult GetSurveyScript(string key)
		{
			string path = @"../TietoFeedbackTool/ClientApp/src/assets/scripts/userSideScript.js";
			var userSideScript = _unitOfWork.TrackingCode.GetScript(key, path);
			if (userSideScript == null)
			{
				return NotFound("Your key or domain is invalid");
			}
			else
			{
				return Content(userSideScript, "text/js");
			}
		}

		/// <summary>
		/// Get dummy script for feedback tool view
		/// </summary>
		/// <returns>Dummy script</returns>
		/// <response code="200">Returns javascript code</response>
		[HttpPost("getdummyscript")]
		[Produces("text/js")]
		public ActionResult GetDummySurveyScript([FromBody] Question question)
		{
			string path = @"../TietoFeedbackTool/ClientApp/src/assets/scripts/dummyScript.js";
			var userSideScript = _unitOfWork.TrackingCode.GetDummyScript(path, question);
			return Content(userSideScript, "text/js");
		}

		/// <summary>
		/// Get styles for feedback tool window
		/// </summary>
		/// <returns>Css style file</returns>
		/// <response code="200">Returns css style code</response>
		[HttpGet("getstyle/{isBottom}")]
		[Produces("text/css")]
		public ActionResult GetSurveyCSS(bool isBottom)
		{
			string path;
			if (isBottom)
			{
				path = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.css";
			}
			else
			{
				path = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBarSide.css";
			}
			var surveyCSS = _unitOfWork.TrackingCode.GetSurveyCSS(path);
			if (surveyCSS == null)
			{
				return NotFound("Cant find Survey style file");
			}
			else
			{
				return Content(surveyCSS, "text/css");
			}
		}

		/// <summary>
		/// Get feedback tool window related to specific key and Domain
		/// </summary>
		/// <param name="key">Account.QuestionsKey</param>
		/// <param name="domain">Question.Domain</param>
		/// <returns>Feedback tool window</returns>
		/// <response code="200">Returns feedback tool window</response>
		[HttpGet("getsurvey/{key}/{domain}")]
		[Produces("text/html")]
		public ActionResult GetSurveyHTMLWithDomain(string key, string domain)
		{
			string path = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
			var surveyHTML = _unitOfWork.TrackingCode.GetSurveyHtmlWithDomain(key, domain, path);
			if (surveyHTML == null)
			{
				return NotFound("Your key or domain is invalid");
			}
			else
			{
				return Content(surveyHTML, "text/html");
			}
		}

		/// <summary>
		/// Get dummy surveys for feedback tool view
		/// </summary>
		/// <returns>Dummy surveys</returns>
		/// <response code="200">Returns dummy surveys</response>
		[HttpPost("getdummysurvey")]
		[Produces("text/html")]
		public ActionResult GetDummySurvey([FromBody] Question question)
		{
			string path = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
			var surveyHTML = _unitOfWork.TrackingCode.GetDummySurveyHtml(path, question);
			return Content(surveyHTML, "text/html");
		}
	}
}
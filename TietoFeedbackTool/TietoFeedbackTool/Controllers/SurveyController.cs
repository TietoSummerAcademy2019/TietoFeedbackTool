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

		[HttpGet("{key}/{Domain}")]
		public ActionResult<Question> GetQuesions(string key, string domain)
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

		//question
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

		[HttpGet("questions")]
		public ActionResult<IEnumerable<Question>> Getquestions()
		{
			var question = _unitOfWork.Question.GetAll();
			if (question == null)
			{
				return NotFound("No questions found, try adding a question");
			}
			else
			{
				return Ok(_unitOfWork.Question.GetAll().ToList());
			}
		}

		[HttpGet("questions/{Id}")]
		public ActionResult<Question> Getquestion(int id)
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

		[HttpPut("questions/{Id}")]
		public ActionResult<Question> Updatequestion(int id, [FromBody]Question question)
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

		[HttpDelete("questions/{Id}")]
		public ActionResult Deletequestion(int id)
		{
			var question = _unitOfWork.Question.Get(id);
			if (question == null)
			{
				return NotFound("Cant find question with this Id");
			}
			else
			{
				_unitOfWork.Question.Remove(question);
				return NoContent();
			}
		}

		[HttpGet("getscript/{key}")]
		[Produces("text/js")]
		public ActionResult<Account> GetSurveyScript(string key)
		{
			var userSideScript = _unitOfWork.TrackingCode.GetScript(key);
			if (userSideScript == null)
			{
				return NotFound("Your key or domain is invalid");
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
				return NotFound("Your key or domain is invalid");
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
				return NotFound("Your key or domain is invalid");
			}
			else
			{
				return Content(surveyHTML, "text/html");
			}
		}
	}
}
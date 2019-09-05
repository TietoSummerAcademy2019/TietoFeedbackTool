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
		public readonly ISurveyRepository _SurveyRepository;
		public readonly IUnitOfWork _unitOfWork;

		public SurveyController(ISurveyRepository SurveyRepository, IUnitOfWork unitOfWork)
		{
			_SurveyRepository = SurveyRepository;
			_unitOfWork = unitOfWork;
		}

		//SURVEYS CRUD
		//Survey
		[HttpPost]
        public void AddSurvey([FromBody]Survey survey)
        {
			var account = _unitOfWork.Account.GetAccount(survey.SurveyKey);
			var _survey = _unitOfWork.Survey.GetSurvey(survey.SurveyKey);
			if (account == null)
			{
				 NotFound("Cant add Survey to not existing Account");
			}
			else if (_survey == null)
			{
				 _unitOfWork.Survey.Add(survey);
			}
			else
			{
				 Conflict("Survey key already exist");
			}
        }

        [HttpGet]
        public ActionResult<IEnumerable<Survey>> GetSurveys()
        {
			var survey = _SurveyRepository.GetAll();
			if (survey == null)
			{
				return NotFound("No Surveys Found, try adding Survey");
			}
			else
			{
				return _SurveyRepository.GetAll().ToList();
			}
        }

		[HttpGet("{SurveyKey}")]
		public ActionResult<Survey> GetSurvey(string surveyKey)
		{
			var survey = _SurveyRepository.GetSurvey(surveyKey);
			if (survey == null)
			{
				return NotFound("Cant find Survey with this Key");
			}
			else
			{
				return survey;
			}
		}

		//[HttpPut("{SurveyKey}")]
		//public ActionResult<Survey> UpdateSurvey(string surveyKey, [FromBody]Survey survey)
		//{
		//	var _survey = _SurveyRepository.GetSurvey(surveyKey);
		//	if (_survey == null)
		//	{
		//		return NotFound("Cant find Survey with this Key");
		//	}
		//	else
		//	{
		//		return _SurveyRepository.UpdateSurvey(surveyKey, survey);
		//	}
		//}

		[HttpDelete("{SurveyKey}")]
		public ActionResult DeleteSurvey(string surveyKey)
		{
			var _survey = _SurveyRepository.GetSurvey(surveyKey);
			if (_survey == null)
			{
				return NotFound("Cant find survey with this Key");
			}
			else
			{
				_unitOfWork.Survey.Remove(_survey);
				return NoContent();
			}
		}

		//SurveyPuzzle
		[HttpPost("questions")]
        public void AddSurveyPuzzle([FromBody]SurveyPuzzle surveyPuzzle)
        {
			var survey = _SurveyRepository.GetSurvey(surveyPuzzle.SurveyKey);
			var puzzleType = _SurveyRepository.Get(surveyPuzzle.PuzzleTypeId);
			if (survey == null)
			{
				NotFound("Cant found Survey");
			}
			else if (puzzleType == null)
			{
				NotFound("Cant found Type of question");
			}
			else
			{
				_unitOfWork.SurveyPuzzle.Add(surveyPuzzle);
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

		//[HttpPut("questions/{Id}")]
		//public ActionResult<SurveyPuzzle> UpdateSurveyPuzzle(int id, [FromBody]SurveyPuzzle surveyPuzzle)
		//{
		//	var _survey = _SurveyRepository.GetSurveyPuzzle(id);
		//	if (_survey == null)
		//	{
		//		return NotFound("Cant find question with this Id");
		//	}
		//	else
		//	{
		//		return _SurveyRepository.UpdateSurveyPuzzle(id, surveyPuzzle);
		//	}
		//}

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
		public void AddPuzzleType([FromBody]PuzzleType puzzleType)
		{
			 _unitOfWork.PuzzleType.Add(puzzleType);
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

		//[HttpPut("type/{Id}")]
		//public ActionResult<PuzzleType> UpdatePuzzleType(int id, PuzzleType puzzleType)
		//{
		//	var _survey = _SurveyRepository.GetPuzzleType(id);
		//	if (_survey == null)
		//	{
		//		return NotFound("Cant find PuzzleType with this id.");
		//	}
		//	else
		//	{
		//		return _SurveyRepository.UpdatePuzzleType(id, puzzleType);
		//	}
		//}

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
				return NoContent();
			}
		}

		[HttpGet("surveywithq/{login}")]
		public ActionResult<Account> GetSurveysWithQuestions(string login)
		{
			var _survey =  _SurveyRepository.GetSurveysWithQuestions(login);
			if (_survey == null)
			{
				return NotFound("Account not found");
			}
			else
			{
				return _survey;
			}			
		}			
	}
}
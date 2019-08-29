using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;
using System;

namespace TietoJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
		public readonly IAnswerService _answerService;
		public readonly ISurveyService _surveyService;

		public AnswerController(IAnswerService answerService, ISurveyService surveyService)
		{
			_answerService = answerService;
			_surveyService = surveyService;
		}

		[HttpPost("open")]
		public ActionResult<OpenPuzzleAnswer> AddOpenPuzzleAnswer([FromBody]OpenPuzzleAnswer openPuzzleAnswer)
		{
			var SurveyPuzzleId = _surveyService.GetPuzzleType(openPuzzleAnswer.SurveyPuzzleId);
			if (SurveyPuzzleId == null)
			{
				return NotFound("Cant find Puzzle Id");
			}
			else
			{
				return _answerService.AddOpenPuzzleAnswer(openPuzzleAnswer);
			}
		}

		[HttpGet("open")]
		public ActionResult<List<OpenPuzzleAnswer>> GetOpenPuzzleAnswers()
		{
			var openPuzzleAnswer = _answerService.GetOpenPuzzleAnswers();
			if (openPuzzleAnswer.Count == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return _answerService.GetOpenPuzzleAnswers();
			}
		}
		[HttpGet("open/{Id}")]
		public ActionResult<List<OpenPuzzleAnswer>> GetOpenPuzzleAnswers(int id)
		{
			var openPuzzleAnswer = _answerService.GetOpenPuzzleAnswers(id);
			if (openPuzzleAnswer.Count == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return _answerService.GetOpenPuzzleAnswers( id);
			}
		}

		[HttpPost("close")]
		public ActionResult<ClosePuzzlePossibility> AddClosePuzzlePossibility([FromBody]ClosePuzzlePossibility closePuzzlePossibility)
		{
			var SurveyPuzzleId = _surveyService.GetSurveyPuzzle(closePuzzlePossibility.SurveyPuzzleId);
			if (SurveyPuzzleId == null)
			{
				return NotFound("Cant find SurveyPuzzleId");
			}
			ClosePuzzlePossibility _closePuzzlePossibility = _answerService.GetClosePuzzlePossibility(closePuzzlePossibility.SurveyPuzzleId, closePuzzlePossibility.Position, closePuzzlePossibility.Answer); 
			if(_closePuzzlePossibility == null)
			{
				closePuzzlePossibility.Counter = 1;
				return _answerService.AddClosePuzzlePossibility(closePuzzlePossibility);
			}
			else
			{
				_closePuzzlePossibility.Answer = closePuzzlePossibility.Answer;
				_closePuzzlePossibility.Counter += 1;
				return _answerService.UpdateClosePuzzlePossibility(_closePuzzlePossibility);
			}			
		}

		[HttpGet("close")]
		public ActionResult<List<ClosePuzzlePossibility>> GetClosePuzzlePossibilities()
		{
			var closePuzzlePossibilities = _answerService.GetClosePuzzlePossibilities();
			if (closePuzzlePossibilities.Count == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return _answerService.GetClosePuzzlePossibilities();
			}
		}

		[HttpGet("close/{Id}")]
		public ActionResult<List<ClosePuzzlePossibility>> GetClosePuzzlePossibilities(int id)
		{
			var closePuzzlePossibilities = _answerService.GetClosePuzzlePossibilities(id);
			if (closePuzzlePossibilities.Count == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return _answerService.GetClosePuzzlePossibilities(id);
			}
		}

		[HttpGet("close/{IdP}/{Id}")]
		public ActionResult<List<ClosePuzzleAnswer>> GetClosePuzzleAnswers(int id)
		{
			var closePuzzleAnswers = _answerService.GetClosePuzzleAnswers(id);
			if (closePuzzleAnswers.Count == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return _answerService.GetClosePuzzleAnswers(id);
			}
		}
	}
}
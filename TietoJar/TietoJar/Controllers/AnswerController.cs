using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;

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
			var puzzleId = _surveyService.GetPuzzleType(openPuzzleAnswer.PuzzleId);
			if (puzzleId == null)
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

		[HttpPost("close")]
		public ActionResult<ClosePuzzlePossibility> AddClosePuzzlePossibility([FromBody]ClosePuzzlePossibility closePuzzlePossibility)
		{
			var puzzleId = _surveyService.GetPuzzleType(closePuzzlePossibility.PuzzleId);
			if (puzzleId == null)
			{
				return NotFound("Cant find puzzleId");
			}
			ClosePuzzlePossibility _closePuzzlePossibility = _answerService.GetClosePuzzlePossibility(closePuzzlePossibility.PuzzleId, closePuzzlePossibility.Position, closePuzzlePossibility.Answer); 
			if(_closePuzzlePossibility == null)
			{
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
			var openPuzzleAnswer = _answerService.GetClosePuzzlePossibilities();
			if (openPuzzleAnswer.Count == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return _answerService.GetClosePuzzlePossibilities();
			}
		}
	}
}
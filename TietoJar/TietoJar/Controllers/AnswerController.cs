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

		public AnswerController(IAnswerService answerService)
		{
			_answerService = answerService;
		}
		[HttpPost("open")]
		public OpenPuzzleAnswer AddOpenPuzzleAnswer([FromBody]OpenPuzzleAnswer openPuzzleAnswer)
		{
			return _answerService.AddOpenPuzzleAnswer(openPuzzleAnswer);
		}
		[HttpGet("open")]
		public List<OpenPuzzleAnswer> GetOpenPuzzleAnswers()
		{
			return _answerService.GetOpenPuzzleAnswers();
		}
		[HttpPost("close")]
		public ClosePuzzlePossibility AddClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility)
		{
			return _answerService.AddClosePuzzlePossibility(closePuzzlePossibility);
		}
		[HttpGet("close")]
		public List<ClosePuzzlePossibility> GetClosePuzzlePossibilities()
		{
			return _answerService.GetClosePuzzlePossibilities();
		}
	}
}
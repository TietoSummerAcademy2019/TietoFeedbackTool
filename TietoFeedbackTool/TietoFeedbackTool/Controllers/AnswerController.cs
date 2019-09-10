using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;
using System;
using System.Linq;

namespace TietoFeedbackTool.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnswerController : Controller
	{
		public readonly IUnitOfWork _unitOfWork;

		public AnswerController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost("open")]
		public ActionResult AddOpenPuzzleAnswer([FromBody]OpenPuzzleAnswer openPuzzleAnswer)
		{
			var SurveyPuzzleId = _unitOfWork.SurveyPuzzle.Get(openPuzzleAnswer.SurveyPuzzleId);
			if (SurveyPuzzleId == null)
			{
				return NotFound("Cant find Puzzle Id");
			}
			else
			{
				_unitOfWork.OpenPuzzleAnswer.Add(openPuzzleAnswer);
				openPuzzleAnswer.SubmitDate = DateTime.Now;
				_unitOfWork.Complete();
				return Ok(openPuzzleAnswer);
			}
		}

		[HttpGet("open")]
		public ActionResult<IEnumerable<OpenPuzzleAnswer>> GetOpenPuzzleAnswers()
		{
			var openPuzzleAnswer = _unitOfWork.OpenPuzzleAnswer.GetAll();
			if (openPuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return Ok(_unitOfWork.OpenPuzzleAnswer.GetAll().ToList());
			}
		}

		[HttpGet("open/{Id}")]
		public ActionResult<IEnumerable<OpenPuzzleAnswer>> GetOpenPuzzleAnswers(int id)
		{
			var openPuzzleAnswer = _unitOfWork.OpenPuzzleAnswer.GetAll().Where(x => x.SurveyPuzzleId == id);
			if (openPuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(openPuzzleAnswer);
			}
		}

		[HttpPost("close")]
		public ActionResult AddClosePuzzlePossibility([FromBody]ClosePuzzlePossibility closePuzzlePossibility)
		{
			var SurveyPuzzleId = _unitOfWork.SurveyPuzzle.Get(closePuzzlePossibility.SurveyPuzzleId);
			if (SurveyPuzzleId == null)
			{
				return NotFound("Cant find SurveyPuzzleId");
			}

			ClosePuzzlePossibility _closePuzzlePossibility = _unitOfWork.ClosePuzzlePossibility.GetClosePuzzlePossibility(closePuzzlePossibility.SurveyPuzzleId, closePuzzlePossibility.Position, closePuzzlePossibility.Answer);

			if (_closePuzzlePossibility == null)
			{
				closePuzzlePossibility.Counter = 1;
				_unitOfWork.ClosePuzzlePossibility.Add(closePuzzlePossibility);
				_unitOfWork.Complete();
				return Ok(closePuzzlePossibility);
			}
			else
			{
				_closePuzzlePossibility.Answer = closePuzzlePossibility.Answer;
				_closePuzzlePossibility.Counter += 1;
				_unitOfWork.ClosePuzzlePossibility.UpdateClosePuzzlePossibility(_closePuzzlePossibility);
				_unitOfWork.Complete();
				return Ok(_closePuzzlePossibility);
			}
		}

		[HttpGet("close")]
		public ActionResult<IEnumerable<ClosePuzzlePossibility>> GetClosePuzzlePossibilities()
		{
			var closePuzzlePossibilities = _unitOfWork.ClosePuzzlePossibility.GetAll();
			if (closePuzzlePossibilities == null)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return Ok(_unitOfWork.ClosePuzzlePossibility.GetAll().ToList());
			}
		}

		[HttpGet("close/{Id}")]
		public ActionResult<IEnumerable<ClosePuzzlePossibility>> GetClosePuzzlePossibilities(int id)
		{
			var closePuzzlePossibilities = _unitOfWork.ClosePuzzlePossibility.GetAll().Where(x => x.SurveyPuzzleId == id);
			if (closePuzzlePossibilities.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(closePuzzlePossibilities);
			}
		}
	}
}
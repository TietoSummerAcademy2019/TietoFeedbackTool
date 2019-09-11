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
			var quesionId = _unitOfWork.Question.Get(openPuzzleAnswer.QuestionId);
			if (quesionId == null)
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
			var openPuzzleAnswer = _unitOfWork.OpenPuzzleAnswer.GetAll().Where(x => x.QuestionId == id);
			if (openPuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(openPuzzleAnswer);
			}
		}		
	}
}
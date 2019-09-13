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

        /// <summary>
        /// Add new open answer
        /// </summary>
        /// <param name="openPuzzleAnswer">OpenPuzzleAnswer object</param>
        /// <returns>Newly added open answer</returns>
        /// <response code="200">Returns the newly created open answer</response>
        [HttpPost("open")]
		public ActionResult AddOpenPuzzleAnswer([FromBody]OpenPuzzleAnswer openPuzzleAnswer)
		{
			var questionId = _unitOfWork.Question.Get(openPuzzleAnswer.QuestionId);
			if (questionId == null)
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

		/// <summary>
		/// Get list of all open answer
		/// </summary>
		/// <returns>List of all open answer</returns>
		/// <response code="200">Returns list of all open answer</response>
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

        /// <summary>
        /// Get list of all asnwer related to specific question
        /// </summary>
        /// <param name="id">OpenPuzzleAnswer.QuestionId</param>
        /// <returns>List of all answer related to specific question</returns>
        /// <response code="200">Returns list of all asnwer related to specific question</response>
        [HttpGet("open/{id}")]
		public ActionResult<IEnumerable<OpenPuzzleAnswer>> GetOpenPuzzleAnswers(int id)
		{
			var openPuzzleAnswer = _unitOfWork.OpenPuzzleAnswer.GetAll().Where(x => x.QuestionId == id).ToList();
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
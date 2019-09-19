using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

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
		/// <param name="PuzzleAnswer">PuzzleAnswer object</param>
		/// <returns>Newly added open answer</returns>
		/// <response code="200">Returns the newly created open answer</response>
		[HttpPost("open")]
		public ActionResult AddPuzzleAnswer([FromBody]PuzzleAnswer PuzzleAnswer)
		{
			var questionId = _unitOfWork.Question.Get(PuzzleAnswer.QuestionId);
			if (questionId == null)
			{
				return NotFound("Cant find Puzzle Id");
			}
			else
			{
				_unitOfWork.PuzzleAnswer.Add(PuzzleAnswer);
				PuzzleAnswer.SubmitDate = DateTime.Now;
				_unitOfWork.Complete();
				return Ok(PuzzleAnswer);
			}
		}

		/// <summary>
		/// Get list of all open answer
		/// </summary>
		/// <returns>List of all open answer</returns>
		/// <response code="200">Returns list of all open answer</response>
		[HttpGet("open")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetPuzzleAnswers()
		{
			var PuzzleAnswer = _unitOfWork.PuzzleAnswer.GetAll();
			if (PuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found, try adding Answer");
			}
			else
			{
				return Ok(_unitOfWork.PuzzleAnswer.GetAll().ToList());
			}
		}

		/// <summary>
		/// Get list of all asnwer related to specific question
		/// </summary>
		/// <param name="id">PuzzleAnswer.QuestionId</param>
		/// <returns>List of all answer related to specific question</returns>
		/// <response code="200">Returns list of all asnwer related to specific question</response>
		[HttpGet("open/{id}")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetPuzzleAnswers(int id)
		{
			var PuzzleAnswer = _unitOfWork.PuzzleAnswer.GetAll().Where(x => x.QuestionId == id).ToList();
			if (PuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(PuzzleAnswer);
			}
		}

		[HttpGet("rating/{id}")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetAnserwRatingList(int id)
		{
			var PuzzleAnswerRating = _unitOfWork.PuzzleAnswer.GetAnserwRatingList(id);
			var PuzzleAnswer = _unitOfWork.PuzzleAnswer.GetAll().Where(x => x.QuestionId == id).ToList();
			if (PuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(PuzzleAnswerRating);
			}
		}

		[HttpGet("rating/{id}/{rating}")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetAnserwsByRatingAndQuestionID(int id, int rating)
		{
			var PuzzleAnswerRating = _unitOfWork.PuzzleAnswer.GetAnserwsByRatingAndQuestionID(id, rating);
			var PuzzleAnswer = _unitOfWork.PuzzleAnswer.GetAll().Where(x => x.QuestionId == id).ToList();
			if (PuzzleAnswer.Count() == 0)
			{
				return NotFound("No Answers Found for this question, try adding Answer");
			}
			else
			{
				return Ok(PuzzleAnswerRating);
			}
		}
	}
}
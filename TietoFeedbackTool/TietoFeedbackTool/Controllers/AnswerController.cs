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
			var question = _unitOfWork.Question.Get(PuzzleAnswer.QuestionId);
			if (question == null)
			{
				return NotFound("Cant find Puzzle Id");
			}
			else
			{
				if (PuzzleAnswer.Rating != null && question.HasRating == false )
				{
					return Conflict("This is question with open answer, You can`t add rating here");
				} else if (PuzzleAnswer.Answer != null && question.HasRating == true)
				{
					return Conflict("This is question with rating, You can`t add open answer here");
				}

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

		/// <summary>
		/// Get list of all ratings
		/// </summary>
		/// <param name="id">PuzzleAnswer.QuestionId</param>
		/// <returns>List of all ratings related to specific question</returns>
		/// <response code="200">Returns list of all ratings related to specific question</response>
		[HttpGet("rating/{id}")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetAnswerRatingList(int id)
		{
			var PuzzleAnswerRating = _unitOfWork.PuzzleAnswer.GetAnswerRatingList(id);
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

		/// <summary>
		/// Get list of all ratings
		/// </summary>
		/// <param name="id">PuzzleAnswer.QuestionId</param>
		/// <param name="rating">PuzzleAnswer.Rating</param>
		/// <returns>List of all ratings related to specific Question with rating id</returns>
		/// <response code="200">Returns list of all ratings related to specific Question with rating id</response>
		[HttpGet("rating/{id}/{rating}")]
		public ActionResult<IEnumerable<PuzzleAnswer>> GetAnswerRatingRepetitions(int id, int rating)
		{
			var PuzzleAnswerRating = _unitOfWork.PuzzleAnswer.GetAnswerRatingRepetitions(id, rating);
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
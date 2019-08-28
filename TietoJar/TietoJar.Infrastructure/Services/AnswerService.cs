using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoJar.Application.Interfaces;
using TietoJar.Persistence;
using TietoJar.Domain;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TietoJar.Infrastructure.Services
{
    public class AnswerService : IAnswerService
    {
        public readonly TietoJarContext _context;

        public AnswerService(TietoJarContext context)
        {
            _context = context;
        }

        //OpenPuzzleAnswer
        public OpenPuzzleAnswer AddOpenPuzzleAnswer(OpenPuzzleAnswer openPuzzleAnswer)
        {
            _context.OpenPuzzleAnswers.Add(openPuzzleAnswer);
            _context.SaveChanges();
            return openPuzzleAnswer;
        }

        public List<OpenPuzzleAnswer> GetOpenPuzzleAnswers()
		{
            return _context.OpenPuzzleAnswers.ToList();
        }
		public List<OpenPuzzleAnswer> GetOpenPuzzleAnswers(int id)
		{
			return _context.OpenPuzzleAnswers.Where(x => x.SurveyPuzzleId == id).ToList();
		}

		//ClosePuzzlePossibility
		public ClosePuzzlePossibility AddClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility)
        {
            _context.ClosePuzzlePossibilities.Add(closePuzzlePossibility);
			ClosePuzzleAnswer closePuzzleAnswer = new ClosePuzzleAnswer();
			closePuzzleAnswer.ClosePuzzlePossibilityId = closePuzzlePossibility.Id;
			closePuzzleAnswer.SubmitDate = DateTime.Now;
			_context.ClosePuzzleAnswers.Add(closePuzzleAnswer);
			_context.SaveChanges();
            return closePuzzlePossibility;
        }

		public List<ClosePuzzlePossibility> GetClosePuzzlePossibilities(int id)
		{
			return _context.ClosePuzzlePossibilities.Where(x => x.SurveyPuzzleId == id).ToList();
		}

		public List<ClosePuzzlePossibility> GetClosePuzzlePossibilities()
        {
            return _context.ClosePuzzlePossibilities.ToList();
		}

		public ClosePuzzlePossibility GetClosePuzzlePossibility(int SurveyPuzzleId, int position, string answer)
		{
			return _context.ClosePuzzlePossibilities.Where(x => x.SurveyPuzzleId == SurveyPuzzleId && x.Position == position && x.Answer == answer).SingleOrDefault();
		}

		public ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility)
		{
			ClosePuzzleAnswer closePuzzleAnswer = new ClosePuzzleAnswer();
			closePuzzleAnswer.ClosePuzzlePossibilityId = closePuzzlePossibility.Id;
			closePuzzleAnswer.SubmitDate = DateTime.Now;
			_context.ClosePuzzleAnswers.Add(closePuzzleAnswer);
			_context.SaveChanges();
			return closePuzzlePossibility;
		}

		public List<ClosePuzzleAnswer> GetClosePuzzleAnswers(int id)
		{
			return _context.ClosePuzzleAnswers.Where(x => x.ClosePuzzlePossibilityId == id).ToList();
		}
	}
}

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
		

        //ClosePuzzlePossibility
        public ClosePuzzlePossibility AddClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility)
        {
            _context.ClosePuzzlePossibilities.Add(closePuzzlePossibility);
            _context.SaveChanges();
            return closePuzzlePossibility;
        }

        public List<ClosePuzzlePossibility> GetClosePuzzlePossibilities()
        {
            return _context.ClosePuzzlePossibilities.ToList();
        }
		public ClosePuzzlePossibility GetClosePuzzlePossibility(int puzzleId, int position, string answer)
		{
			return _context.ClosePuzzlePossibilities.Where(x => x.PuzzleId == puzzleId && x.Position == position && x.Answer == answer).SingleOrDefault();
		}

		public ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility)
		{
			_context.SaveChanges();
			return closePuzzlePossibility;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;
using TietoFeedbackTool.Persistence;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ITietoFeedbackToolContext _context;
		public IAccountRepository Account { get; private set; }
		public ISurveyRepository Survey { get; private set; }
		public ISurveyPuzzleRepository SurveyPuzzle { get; private set; }
		public IPuzzleTypeRepository PuzzleType { get; private set; }
		public IOpenPuzzleAnswerRepository OpenPuzzleAnswer { get; private set; }
		public IClosePuzzlePossibilityRepository ClosePuzzlePossibility { get; private set; }
		public IClosePuzzleAnswerRepository ClosePuzzleAnswer { get; private set; }
		public ITrackingCodeRepository TrackingCode { get; private set; }
        public UnitOfWork(ITietoFeedbackToolContext context)
        {
			_context = context;
			Account = new AccountRepository(_context);
			Survey = new SurveyRepository(_context);
			SurveyPuzzle = new SurveyPuzzleRepository(_context);
			PuzzleType = new PuzzleTypeRepository(_context);
			OpenPuzzleAnswer = new OpenPuzzleAnswerRepository(_context);
			ClosePuzzlePossibility = new ClosePuzzlePossibilityRepository(_context);
			ClosePuzzleAnswer = new ClosePuzzleAnswerRepository(_context);
			TrackingCode = new TrackingCodeRepository(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			(_context as TietoFeedbackToolContext).Dispose();
		}
	}
}

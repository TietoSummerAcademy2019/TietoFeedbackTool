using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ITietoFeedbackToolContext _context;
		public IAccountRepository Account { get; private set; }
		public IQuestionRepository Question { get; private set; }
		public IPuzzleAnswerRepository PuzzleAnswer { get; private set; }
		public ITrackingCodeRepository TrackingCode { get; private set; }

		public UnitOfWork(ITietoFeedbackToolContext context)
		{
			_context = context;
			Account = new AccountRepository(_context);
			Question = new QuestionRepository(_context);
			PuzzleAnswer = new PuzzleAnswerRepository(_context);
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

using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;

namespace TietoFeedbackTool.Infrastructure.Services
{
	/// <summary>
	/// Implementation of repository pattern, unit of work.
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ITietoFeedbackToolContext _context;
		public IAccountRepository Account { get; private set; }
		public IQuestionRepository Question { get; private set; }
		public IPuzzleAnswerRepository PuzzleAnswer { get; private set; }
		public ITrackingCodeRepository TrackingCode { get; private set; }

		/// <summary>
		/// Method creates when implement singleton service of specific service.
		/// </summary>
		/// <param name="context">databse contex</param>
		public UnitOfWork(ITietoFeedbackToolContext context)
		{
			_context = context;
			Account = new AccountRepository(_context);
			Question = new QuestionRepository(_context);
			PuzzleAnswer = new PuzzleAnswerRepository(_context);
			TrackingCode = new TrackingCodeRepository(_context);
		}

		/// <summary>
		/// Save changes in database
		/// </summary>
		public int Complete()
		{
			return _context.SaveChanges();
		}

		/// <summary>
		/// Use dispose as database.
		/// </summary>
		public void Dispose()
		{
			(_context as TietoFeedbackToolContext).Dispose();
		}
	}
}

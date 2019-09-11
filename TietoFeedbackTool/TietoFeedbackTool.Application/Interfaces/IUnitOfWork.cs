using System;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IAccountRepository Account { get; }
		IQuestionRepository Question { get; }
		IOpenPuzzleAnswerRepository OpenPuzzleAnswer { get; }
		ITrackingCodeRepository TrackingCode { get; }
		int Complete();
	}
}

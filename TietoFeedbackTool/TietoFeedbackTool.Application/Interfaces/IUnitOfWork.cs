using System;
using System.Collections.Generic;
using System.Text;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IAccountRepository Account { get; }
		ISurveyRepository Survey { get; }
		ISurveyPuzzleRepository SurveyPuzzle { get; }
		IPuzzleTypeRepository PuzzleType { get; }
		int Complete();
	}
}

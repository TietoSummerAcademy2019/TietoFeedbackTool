using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IClosePuzzleAnswerRepository : IRepository<ClosePuzzleAnswer>
	{
		List<ClosePuzzleAnswer> GetClosePuzzleAnswers(int id);
	}
}

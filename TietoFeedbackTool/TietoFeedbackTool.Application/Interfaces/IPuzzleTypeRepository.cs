using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IPuzzleTypeRepository : IRepository<PuzzleType>
	{
		void UpdatePuzzleType(PuzzleType puzzleType, int id);
	}
}

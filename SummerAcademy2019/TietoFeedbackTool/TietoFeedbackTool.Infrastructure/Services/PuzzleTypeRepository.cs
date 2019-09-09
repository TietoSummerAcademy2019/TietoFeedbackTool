using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class PuzzleTypeRepository : Repository<PuzzleType>, IPuzzleTypeRepository
	{
		public PuzzleTypeRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public void UpdatePuzzleType(PuzzleType puzzleType, int id)
		{
			var _puzzleType = _context.PuzzleTypes.SingleOrDefault(x => x.Id == id);
			_puzzleType.Name = puzzleType.Name;
		}
	}
}

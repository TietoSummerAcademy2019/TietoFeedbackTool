using System;
using System.Collections.Generic;
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
	}
}

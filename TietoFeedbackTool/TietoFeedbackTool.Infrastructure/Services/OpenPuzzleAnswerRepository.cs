using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoFeedbackTool.Infrastructure.Services
{
    public class PuzzleAnswerRepository : Repository<PuzzleAnswer>,  IPuzzleAnswerRepository
    {
		public PuzzleAnswerRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}
	}
}
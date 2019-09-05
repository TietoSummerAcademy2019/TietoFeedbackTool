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
		private readonly TietoFeedbackToolContext _context;
		public IAccountService Account { get; private set; }
		public UnitOfWork(TietoFeedbackToolContext context)
		{
			_context = context;
			Account = new AccountService(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}

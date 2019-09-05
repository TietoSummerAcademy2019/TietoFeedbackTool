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
		private readonly ITietoFeedbackToolContext _context;
		public IAccountRepository Account { get; private set; }
		public UnitOfWork(ITietoFeedbackToolContext context)
		{
			_context = context;
			Account = new AccountRepository(_context);
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

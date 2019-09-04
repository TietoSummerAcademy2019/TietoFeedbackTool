using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;



namespace TietoFeedbackTool.Infrastructure.Services
{
	public class AccountService : Repository<Account>, IAccountService
	{
		public AccountService(TietoFeedbackToolContext context) : base(context)
		{
		}

		public Account GetAccount(string login)
		{
			return TietoFeedbackToolContext.Accounts.SingleOrDefault(x => x.Login == login);
		}
		public TietoFeedbackToolContext TietoFeedbackToolContext
		{
			get { return _context as TietoFeedbackToolContext; }
		}
	}
}

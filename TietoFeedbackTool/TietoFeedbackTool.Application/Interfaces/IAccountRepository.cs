using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IAccountRepository : IRepository<Account>
	{
		new Account GetByString(string login);
		new Account Add(Account account);
		void UpdateAccount(Account account, string login);
	}
}
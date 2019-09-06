using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IAccountRepository : IRepository<Account>
	{
		Account GetAccount(string login);
		void UpdateAccount(Account account, string login);
	}
}
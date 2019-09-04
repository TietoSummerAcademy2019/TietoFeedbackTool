using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface IAccountService : IRepository<Account>
	{
        Account GetAccount(string login);

    }
}
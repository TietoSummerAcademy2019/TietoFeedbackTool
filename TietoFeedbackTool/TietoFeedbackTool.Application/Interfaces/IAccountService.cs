using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        Account AddAccount(Account account);
        Account GetAccount(string login);
        Account UpdateAccount(string login, Account account);
        void DeleteAccount(string login);
    }
}
using System.Collections.Generic;
using TietoJar.Domain;

namespace TietoJar.Application.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        Account AddAccount(Account account);
        Account GetAccount(string login);
        Account UpdateAccountById(int id, Account account);
        void DeleteAccount(string login);
    }
}
using Xunit;
using TietoJar.Domain;
using System.Collections.Generic;

namespace TietoJar.Test
{
	[Collection("AccountColletion")]
	public class AccountServiceTest
	{
		TestAccountDatabase DB;

		public AccountServiceTest(TestAccountDatabase DB)
		{
			this.DB = DB;
		}

		[Fact]
		public void TestAddAccount()
		{
			//Arrange
			int expected = 3;
			Account newAccount = new Account() { Login = "Roman", Name = "Roman Barbarzyńca", Password = "TotalySafePassword" };

			//Act
			DB.accountService.AddAccount(newAccount);
			int accountsNumberAfter = DB.accountService.GetAccounts().Count;

			//Assert
			Assert.Equal(expected, accountsNumberAfter);
		}

		[Fact]
		public void TestGetAccounts()
		{
			//Arrange

			//Act
			List<Account> accountList = DB.accountService.GetAccounts();

			//Assert
			Assert.Equal(DB.accounts, accountList);
		}

		[Fact]
		public void TestGetAccount()
		{
			//Arrange

			//Act
			Account account = DB.accountService.GetAccount("Hollywood");

			//Assert
			Assert.Equal("Roman", account.Login);
			Assert.Equal("Roman Barbarzyńca", account.Name);
			Assert.Equal("TotalySafePassword", account.Password);
		}
	}
}
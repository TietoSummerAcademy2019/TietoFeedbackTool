using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;
using TietoJar.Infrastructure.Services;
using TietoJar.Persistence;
using Xunit;

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
		public void TestGetAccount()
		{
			//Arrange

			//Act
			List<Account> accountList = DB.accountService.GetAccounts();

			//Assert
			Assert.Equal(DB.accounts, accountList);
		}
	}
}

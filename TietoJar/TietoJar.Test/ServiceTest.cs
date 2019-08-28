using System;
using System.Collections.Generic;
using System.Linq;
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
	public class ServiceTest
	{
		public ISurveyService _surveyService;
		public IAccountService _accountService;

		[Fact]
		public void TestTests()
		{
			Assert.True(true);
		}

		[Fact]
		public void TestAddAccount()
		{
			int expected = 4;
			var users = new List<Account>
			{
				new Account(){ Login = "BBB" , Name="AAA" , Password="asd" },
				new Account { Login = "ASF" , Name="ASD" , Password="AFSFA"},
				new Account { Login = "ASDF" , Name="AFS" , Password="ASF"}
			}.AsQueryable();

			var usersMock = new Mock<DbSet<Account>>();
			usersMock.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(users.Provider);
			usersMock.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(users.Expression);
			usersMock.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(users.ElementType);
			usersMock.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

			//users.Where(user => user.Login.Contains("Lukasz"));
			//var u2 = users.AsEnumerable();
			//users.Where(user => user.Login.Contains("Lukasz"));

			var userContextMock = new Mock<ITietoJarContext>();
			var userContextMockWithoutInterface = new Mock<TietoJarContext>();

			userContextMock.Setup(x => x.Accounts).Returns(usersMock.Object) ;
			userContextMockWithoutInterface.Setup(x => x.Accounts).Returns(usersMock.Object);

			var accountService = new AccountService(userContextMock.Object);
			var accountServiceWithoutInterface = new AccountService(userContextMockWithoutInterface.Object);

			Account newAccount = new Account() { Name = "Roman Barbarzyńca", Login = "Roman", Password = "TotalySafePassword" };
			accountService.AddAccount(newAccount);
			var u3 = accountService.GetAccounts();
			var u4 = accountService.GetAccounts();
			var u5 = accountServiceWithoutInterface.GetAccounts();

			accountService.AddAccount(newAccount);
			int accountsNumberAfter = accountService.GetAccounts().Count;
			//_accountService.DeleteAccount("Roman");

			Assert.Equal(expected, accountsNumberAfter);
		}

		[Fact]
		public void TestChangeLogin()
		{
			string login = "NewBetterLogin";
			Account account1 = _accountService.GetAccount("Roman");

			_accountService.UpdateAccount(login, account1);
			Account account2 = _accountService.GetAccount("NewBetterLogin");

			Assert.Same(account1,account2);
		}

		[Fact]
		public void TestSameUserException()
		{
			Assert.True(true);
		}
	}
}

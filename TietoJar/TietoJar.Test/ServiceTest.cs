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
	public class ServiceTest
	{
		[Fact]
		public void TestTests()
		{
			Assert.True(true);
		}

		[Fact]
		public void TestAddAccount()
		{
			//Arrange
			int expected = 4;
			var users = new List<Account>
			{
				new Account { Login = "Jon_doeeros" , Name="Jon" , Password="6934c4368e77e0a4e6008ae5c16fcd5d" },
				new Account { Login = "BestOfTheBest" , Name="Janusz" , Password="7b064dad507c266a161ffc73c53dcdc5"},
				new Account { Login = "Kango123" , Name="Kangoroo" , Password="d9729feb74992cc3482b350163a1a010"}
			};

			var usersMock = new Mock<DbSet<Account>>();
			usersMock.As<IEnumerable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());
			usersMock.Setup(d => d.Add(It.IsAny<Account>())).Callback<Account>((s) => users.Add(s));
			var userContextMock = new Mock<ITietoJarContext>();
			var userContextMockWithoutInterface = new Mock<TietoJarContext>();
			userContextMock.Setup(x => x.Accounts).Returns(usersMock.Object) ;
			var accountService = new AccountService(userContextMock.Object);
			Account newAccount = new Account() { Login = "Roman", Name = "Roman Barbarzyńca", Password = "TotalySafePassword" };

			//Act
			accountService.AddAccount(newAccount);
			int accountsNumberAfter = accountService.GetAccounts().Count;

			//Assert
			Assert.Equal(expected, accountsNumberAfter);
		}

		[Fact]
		public void TestGetAccount()
		{
			//Arrange
			var users = new List<Account>
			{
				new Account { Login = "Hollywood" , Name="Richard" , Password="6934c4368e77e0a4e6008ae5c16fcd5d" },
				new Account { Login = "PanPaweł" , Name="Paweł" , Password="d9729feb74992cc3482b350163a1a010" },
			};

			var usersMock = new Mock<DbSet<Account>>();
			usersMock.As<IEnumerable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());
			usersMock.Setup(d => d.Add(It.IsAny<Account>())).Callback<Account>((s) => users.Add(s));
			var userContextMock = new Mock<ITietoJarContext>();
			var userContextMockWithoutInterface = new Mock<TietoJarContext>();
			userContextMock.Setup(x => x.Accounts).Returns(usersMock.Object);
			var accountService = new AccountService(userContextMock.Object);

			//Act
			List<Account> accountList = accountService.GetAccounts();

			//Assert
			Assert.Equal(users, accountList);
		}
	}
}



using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Domain;
using TietoFeedbackTool.Infrastructure.Services;
using TietoFeedbackTool.Persistence;
using Xunit;

namespace TietoFeedbackTool.Test
{
	[Collection("AccountColletion")]
	public class AccountServiceTestInMemory
	{
		public AccountServiceTestInMemory() { }

		[Fact]
		public void TestAddAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;
			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new AccountRepository(context);
				Account newAccount = new Account() { Login = "Cesar", Name = "Juliusz Cesar"};
				//Act
				service.Add(newAccount);
				context.SaveChanges();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new AccountRepository(context);
				Assert.Equal("Cesar", context.Accounts.Find("Cesar").Login);
				Assert.Equal("Juliusz Cesar", context.Accounts.Find("Cesar").Name);
			}
		}

		[Fact]
		public void TestGetAccounts()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new AccountRepository(context);
				Account newAccount2 = new Account() { Login = "Jeff", Name = "My name is Jeff" };

				//Act
				service.Add(newAccount2);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new AccountRepository(context);

				//Act
				IEnumerable<Account> accountList = service.GetAll().ToList();

				//Assert
				Assert.Equal(context.Accounts, accountList);
			}
		}

		[Fact]
		public void TestGetAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new AccountRepository(context);

				//Act
				Account account = service.GetAccount("Cesar");

				//Assert
				Assert.Equal(context.Accounts.Find("Cesar").Login, account.Login);
				Assert.Equal(context.Accounts.Find("Cesar").Name, account.Name);
			}
		}

		[Fact]
		public void TestUpdateAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new AccountRepository(context);
				Account newAccount = new Account() { Login = "Brutus", Name = "The Brutus" };
				service.Add(newAccount);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new AccountRepository(context);
				Account account = new Account() { Login = "Brutus", Name = "Roman The Barbarian" };

				//Act
				service.UpdateAccount(account,"Brutus");
				context.SaveChanges();

				//Assert
				Assert.Equal("Brutus", context.Accounts.Find("Brutus").Login);
				Assert.Equal("Roman The Barbarian", context.Accounts.Find("Brutus").Name);
			}
		}
	}
}
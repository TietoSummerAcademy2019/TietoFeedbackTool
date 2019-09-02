using Xunit;
using TietoJar.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TietoJar.Persistence;
using TietoJar.Infrastructure.Services;
using System.Linq;
namespace TietoJar.Test
{
	[Collection("AccountColletion")]
	public class AccountServiceTestInMemory
	{
		public AccountServiceTestInMemory()
		{
		}

		[Fact]
		public void TestAddAccount()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;
			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new AccountService(context);
				Account newAccount = new Account() { Login = "Cesar", Name = "Juliusz Cesar", Password = "TotalySafePassword" };
				//Act
				service.AddAccount(newAccount);
				context.SaveChanges();
			}
			//Assert
			using (var context = new TietoJarContext(options))
			{
				var service = new AccountService(context);
				Account account = service.GetAccount("Cesar");
				Assert.Equal("Cesar", account.Login);
				Assert.Equal("Juliusz Cesar", account.Name);
				Assert.Equal("TotalySafePassword", account.Password);
			}
		}

		[Fact]
		public void TestGetAccounts()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new AccountService(context);
				Account newAccount2 = new Account() { Login = "Jeff", Name = "My name is Jeff", Password = "TotalySafePassword" };

				//Act
				service.AddAccount(newAccount2);
				context.SaveChanges();
			}

			using (var context = new TietoJarContext(options))
			{
				var service = new AccountService(context);

				//Act
				List<Account> accountList = service.GetAccounts();

				//Assert
				Assert.Equal(context.Accounts, accountList);
			}
		}

		[Fact]
		public void TestGetAccount()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new AccountService(context);

				//Act
				Account account = service.GetAccount("Cesar");

				//Assert
				Assert.Equal("Cesar", account.Login);
				Assert.Equal("Juliusz Cesar", account.Name);
				Assert.Equal("TotalySafePassword", account.Password);
			}
		}

		[Fact]
		public void TestUpdateAccount()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new AccountService(context);
				Account newAccount = new Account() { Login = "Brutus", Name = "The Brutus", Password = "TotalySafePassword" };
				//Act
				service.AddAccount(newAccount);
				context.SaveChanges();
			}

			using (var context = new TietoJarContext(options))
			{
				var service = new AccountService(context);
				Account account = new Account() { Login = "RomanChanged", Name = "Roman The Barbarian", Password = "RomanSecurePassword" };

				//Act
				service.UpdateAccount("Brutus", account);
				context.SaveChanges();

				//Assert
				Assert.Equal("RomanChanged", account.Login);
				Assert.Equal("Roman The Barbarian", account.Name);
				Assert.Equal("RomanSecurePassword", account.Password);
			}
		}
	}
}
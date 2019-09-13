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
		public void Add_SingleAccount_ReturnsSameAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Cesar", Name = "Juliusz Cesar"};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Cesar");
				Assert.Equal("Cesar", account.Login);
				Assert.Equal("Juliusz Cesar", account.Name);
				unitOfWork.Dispose();
;			}
		}

		[Fact]
		public void Get_ListOfAccounts_ReturnsSameListOfAccounts()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				var accounts = new List<Account>
				{
					new Account { Login = "Jeff", Name = "My name is Jeff" },
					new Account { Login = "Lech", Name = "My name is Lech" },
					new Account { Login = "Czech", Name = "My name is Czech" },
					new Account { Login = "Rus", Name = "My name is Rus" }
			};

				//Act
				unitOfWork.Account.AddRange(accounts);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				IEnumerable<Account> accountList = unitOfWork.Account.GetAll().ToList();
				var expected = context.Accounts;
				//Assert
				Assert.Equal(expected, accountList);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_SingleAccount_ReturnSameAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Cesar", Name = "Juliusz Cesar" };
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				Account account = unitOfWork.Account.GetByString("Cesar");

				//Assert
				Assert.Equal(context.Accounts.Find("Cesar").Login, account.Login);
				Assert.Equal(context.Accounts.Find("Cesar").Name, account.Name);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Update_Account_ReturnUpdatedAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Brutus", Name = "The Brutus" };
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account account = new Account() { Login = "Brutus", Name = "Roman The Barbarian" };

				//Act
				unitOfWork.Account.UpdateAccount(account,"Brutus");
				unitOfWork.Complete();
				var updated = unitOfWork.Account.GetByString("Brutus");

				//Assert
				Assert.Equal("Brutus", updated.Login);
				Assert.Equal("Roman The Barbarian", updated.Name);
				unitOfWork.Dispose();
			}
		}
		[Fact]
		public void Remove_SingleAccount_ReturnsNull()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Bomba", Name = "Kapitan Bomba" };
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Bomba");
				unitOfWork.Account.Remove(account);
				unitOfWork.Complete();
				var expected = unitOfWork.Account.Find(x => x.Login == "Bomba").SingleOrDefault();
				account = unitOfWork.Account.GetByString("Bomba");
				Assert.Equal(expected, account);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Add_AccountWithQuestionKey_ReturnsAccountWithGeneratedQuestionKey()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Geralt", QuestionsKey ="NienawidzePortali123", Name = "Geralt z Rivii" };
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Geralt");
				var expected = account.QuestionsKey;
				Assert.True(expected != "NienawidzePortali123");
				unitOfWork.Dispose();
			}
		}
	}
}
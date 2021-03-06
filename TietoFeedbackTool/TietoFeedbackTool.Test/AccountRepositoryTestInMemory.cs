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
	public class AccountRepositoryTestInMemory
	{
		public AccountRepositoryTestInMemory() { }

		[Fact]
		public void Add_SingleAccount_Returns_SameAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Add_SingleAccount_Returns_SameAccount")
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
			}
		}

		[Fact]
		public void Get_ListOfAccounts_Returns_SameListOfAccounts()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_ListOfAccounts_Returns_SameListOfAccounts")
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
				var accountList = unitOfWork.Account.GetAll().ToList();
				var expected = context.Accounts;
				//Assert
				Assert.Equal(expected, accountList);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_SingleAccount_Returns_SameAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_SingleAccount_Returns_SameAccount")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Harry", Name = "Harry Potter" };
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				Account account = unitOfWork.Account.GetByString("Harry");

				//Assert
				Assert.Equal(context.Accounts.Find("Harry").Login, account.Login);
				Assert.Equal(context.Accounts.Find("Harry").Name, account.Name);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Update_Account_Returns_UpdatedAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Update_Account_Returns_UpdatedAccount")
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
		public void Remove_SingleAccount_Returns_Null()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Remove_SingleAccount_Returns_Null")
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
		public void Add_AccountWithQuestionKey_Returns_AccountWithGeneratedQuestionKey()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Add_AccountWithQuestionKey_Returns_AccountWithGeneratedQuestionKey")
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

		[Fact]
		public void Get_ListOfUserDomains_Returns_SameList()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_ListOfUserDomains_Returns_SameList")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				var accounts = new List<Account>
				{
					new Account() { Login = "Iorweth", Name = "Lis Puszczy" },
					new Account() { Login = "Vernon", Name = "Vernon Roche" }
				};
				unitOfWork.Account.AddRange(accounts);
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Iorweth", Domain = "localhost:42345", QuestionText = "Do You like feedbacktool?", Enabled = true, HasRating = true},
					new Question {  AccountLogin = "Iorweth", Domain = "localhost:52345", QuestionText = "Are you free tonight?", Enabled = true, HasRating = false },
					new Question {  AccountLogin = "Iorweth", Domain = "localhost:62345", QuestionText = "Wanna go out for beer?", Enabled = true, HasRating = true },
					new Question {  AccountLogin = "Vernon", Domain = "localhost:12345", QuestionText = "Wanna go out for beer?", Enabled = true, HasRating = true },
					new Question {  AccountLogin = "Vernon", Domain = "localhost:12346", QuestionText = "Wanna go out for beer?", Enabled = true, HasRating = false },
					new Question {  AccountLogin = "Vernon", Domain = "localhost:12347", QuestionText = "Wanna go out for beer?", Enabled = true, HasRating = true }
				};
				unitOfWork.Question.AddRange(questions);

				//Act
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var domain = unitOfWork.Account.GetUserDomains("Iorweth");
				Assert.NotNull(domain);
				Assert.Equal(3, domain.Count);
				unitOfWork.Dispose();
			}
		}
	}
}
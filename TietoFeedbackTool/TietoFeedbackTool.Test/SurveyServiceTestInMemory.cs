using Xunit;
using TietoFeedbackTool.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Infrastructure.Services;
using System.Linq;

namespace TietoFeedbackTool.Test
{
	[Collection("QuestionColletion")]
	public class QuestionServiceTestInMemory
	{
		public QuestionServiceTestInMemory() { }

		[Fact]
		public void TestGetQuestions()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "TestGetQuestions")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Peter", Name = "Peter Snow" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Peter", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Peter", Domain = "localhost:44444", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Peter", Domain = "localhost:44333", QuestionText = "Wanna go out for beer?", Enabled = true },
					new Question {  AccountLogin = "Peter", Domain = "localhost:44355", QuestionText = "Which one to go to the toilet?", Enabled = true },
					new Question {  AccountLogin = "Peter", Domain = "localhost:40000", QuestionText = "What do you think about our new functionality?", Enabled = true }
				};
				unitOfWork.Question.AddRange(questions);
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);

				//Act
				var questionList = unitOfWork.Question.GetAll().ToList();
				var expected = context.Question;

				//Assert
				Assert.Equal(expected, questionList);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestGetQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "TestGetQuestion")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Richard", Name = "Richardo" };
				Question newQuestion = new Question() { AccountLogin = "Richard", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				var account = unitOfWork.Account.GetByString("Richard");
				var question = account.Questions[0];
				var expected = unitOfWork.Question.Find(x => x.Id == 1).SingleOrDefault();

				//Assert
				Assert.Equal(expected, question);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestAddQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "TestAddQuestion")
							.Options;

			//Arrage
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Johnny", Name = "Johnny Mnemonic" };
				Question newQuestion = new Question() { AccountLogin = "Johnny", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				var account = unitOfWork.Account.GetByString("Johnny");
				var question = account.Questions[0];

				//Assert
				Assert.True(question.Enabled);
				Assert.Equal("Johnny", question.AccountLogin);
				Assert.Equal("Do You like feedbacktool?", question.QuestionText);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestUpdateQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "TestUpdateQuestion")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Sauron", Name = "Sauron the cat" };
				Question newQuestion = new Question() { AccountLogin = "Sauron", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question survey = new Question() { AccountLogin = "Sauron", QuestionText = "How happy are You today?", Enabled = false };

				//Act
				var account = unitOfWork.Account.GetByString("Sauron");
				unitOfWork.Question.UpdateQuestion(survey, account.Questions[0].Id);
				unitOfWork.Complete();
				var updated = account.Questions[0];

				//Assert
				Assert.False(updated.Enabled);
				Assert.Equal("Sauron", updated.AccountLogin);
				Assert.Equal("How happy are You today?", updated.QuestionText);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestRemoveQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "TestRemoveQuestion")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Beliar", Name = "Beliar the god" };
				Question newQuestion = new Question() { AccountLogin = "Beliar", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				var account = unitOfWork.Account.GetByString("Beliar");
				var question = account.Questions[0];
				unitOfWork.Question.Remove(question);
				unitOfWork.Complete();

				//Assert
				Assert.Empty(account.Questions);
				unitOfWork.Dispose();
			}
		}
	}
}
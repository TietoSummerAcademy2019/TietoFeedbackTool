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
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var questions = new List<Question>
				{
					new Question { Id = 1, AccountLogin = "Jon", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question { Id = 2, AccountLogin = "Lech", Domain = "localhost:44444", QuestionText = "Are you free tonight?", Enabled = true },
					new Question { Id = 3, AccountLogin = "Czech", Domain = "localhost:44333", QuestionText = "Wanna go out for beer?", Enabled = true },
					new Question { Id = 4, AccountLogin = "Rus", Domain = "localhost:44355", QuestionText = "Which one to go to the toilet?", Enabled = true },
					new Question { Id = 5, AccountLogin = "Pawel", Domain = "localhost:40000", QuestionText = "What do you think about our new functionality?", Enabled = true }
				};
				unitOfWork.Question.AddRange(questions);
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
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question newQuestion = new Question() { Id = 6, AccountLogin = "Jon", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				var question = unitOfWork.Question.Get(6);
				var expected = unitOfWork.Question.Find(x => x.Id == 6).SingleOrDefault();

				//Assert
				Assert.Equal(expected, question);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestAddQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrage
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question newQuestion = new Question() { Id = 7, AccountLogin = "Jon", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				Question question = unitOfWork.Question.Get(7);

				//Assert
				Assert.True(question.Enabled);
				Assert.Equal("Jon", question.AccountLogin);
				Assert.Equal("Do You like feedbacktool?", question.QuestionText);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestUpdateQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question newQuestion = new Question() { Id = 8, AccountLogin = "Jon", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question survey = new Question() { Id = 8, AccountLogin = "Jon", QuestionText = "How happy are You today?", Enabled = false };

				//Act
				unitOfWork.Question.UpdateQuestion(survey, 8);
				unitOfWork.Complete();
				var updated = unitOfWork.Question.Get(8);

				//Assert
				Assert.False(updated.Enabled);
				Assert.Equal("Jon", updated.AccountLogin);
				Assert.Equal("How happy are You today?", updated.QuestionText);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void TestRemoveQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				Question newQuestion = new Question() { Id = 9, AccountLogin = "Jon", Domain = "localhost:44350", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);

				//Act
				var question = unitOfWork.Question.Get(9);
				unitOfWork.Question.Remove(question);
				unitOfWork.Complete();
				var expected = unitOfWork.Question.Find(x => x.Id == 9).SingleOrDefault();
				question = unitOfWork.Question.Get(9);

				//Assert
				Assert.Equal(expected, question);
				unitOfWork.Dispose();
			}
		}
	}
}
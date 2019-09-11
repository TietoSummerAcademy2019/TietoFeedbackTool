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
				//Arrange
				var service = new QuestionRepository(context);

				//Act
				var questionList = service.GetAll().ToList();

				//Assert
				Assert.Equal(context.Question, questionList);
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
				var service = new QuestionRepository(context);
				Question newQuestion = new Question() { Id = 1, AccountLogin = "Jon", QuestionText = "Do You like feedbacktool?", Enabled = true };
				service.Add(newQuestion);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);

				//Act
				Question question = service.Get(1);

				//Assert
				Assert.True(context.Question.Find(1).Enabled);
				Assert.Equal("Jon", context.Question.Find(1).AccountLogin);
				Assert.Equal("Do You like feedbacktool?", context.Question.Find(1).QuestionText);
			}
		}

		[Fact]
		public void TestUpdateQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			int id = 2;
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);
				Question newQuestion = new Question() { Id = id, AccountLogin = "Jon", QuestionText = "Do You like feedbacktool?" , Enabled=true};
				service.Add(newQuestion);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);
				Question survey = new Question() { Id = id, AccountLogin = "Jon", QuestionText = "How happy are You today?", Enabled = false };

				//Act
				service.UpdateQuestion(survey, id);
				context.SaveChanges();

				//Assert
				Assert.False(context.Question.Find(id).Enabled);
				Assert.Equal("Jon", context.Question.Find(id).AccountLogin);
				Assert.Equal("How happy are You today?", context.Question.Find(id).QuestionText);
			}
		}
	}
}
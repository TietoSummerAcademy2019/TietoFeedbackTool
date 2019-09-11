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

		[Fact(Skip = "model changes")]
		public void TestAddQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;
			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new QuestionRepository(context);
				//Question newQuestion = new Question() { QuestionKey = "6D4EBFCA6358A3B4E040EA75POL6E74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				//Act
				//service.Add(newQuestion);
				context.SaveChanges();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);
				//Assert.Equal("6D4EBFCA6358A3B4E040EA75POL6E74C", context.Question.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").QuestionKey);
				Assert.Equal("Jon", context.Question.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").AccountLogin);
				//Assert.Equal("Jon`s survey", context.Question.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").Name);
			}
		}

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
				List<Question> surveysList = service.GetAll().ToList();

				//Assert
				Assert.Equal(context.Question, surveysList);
			}
		}

		[Fact(Skip = "specific reason")]
		public void TestGetQuestion()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrage
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);
				//Question newQuestion = new Question() { QuestionKey = "6D4EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				//service.Add(newQuestion);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);

				//Act
				Question survey = service.GetByString("6D4EBFCA6358ANHYE040EA75QWERT74C");

				//Assert
				//Assert.Equal("6D4EBFCA6358ANHYE040EA75QWERT74C", survey.QuestionKey);
				Assert.Equal("Jon", survey.AccountLogin);
				//Assert.Equal("Jon`s survey", survey.Name);
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
				var service = new QuestionRepository(context);
				Question newQuestion = new Question() { Id=1, AccountLogin = "Jon", QuestionText = "Do You like feedbacktool?" , Enabled=true};
				service.Add(newQuestion);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new QuestionRepository(context);
				Question survey = new Question() { Id = 1, AccountLogin = "Jon", QuestionText = "How happy are You today?", Enabled = false };

				//Act
				service.UpdateQuestion(survey,1);
				context.SaveChanges();

				//Assert
				Assert.False(context.Question.Find(1).Enabled);
				Assert.Equal("Jon", context.Question.Find(1).AccountLogin);
				Assert.Equal("How happy are You today?", context.Question.Find(1).QuestionText);
			}
		}
	}
}
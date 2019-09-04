using Xunit;
using TietoFeedbackTool.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Infrastructure.Services;
using System.Linq;

namespace TietoFeedbackTool.Test
{
	[Collection("SurveyColletion")]
	public class SurveyServiceTestInMemory
	{
		public SurveyServiceTestInMemory() { }

		[Fact]
		public void TestAddSurvey()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;
			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "6D4EBFCA6358A3B4E040EA75POL6E74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				//Act
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new SurveyService(context);
				Assert.Equal("6D4EBFCA6358A3B4E040EA75POL6E74C", context.Surveys.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").SurveyKey);
				Assert.Equal("Jon", context.Surveys.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").AccountLogin);
				Assert.Equal("Jon`s survey", context.Surveys.Find("6D4EBFCA6358A3B4E040EA75POL6E74C").Name);
			}
		}

		[Fact]
		public void TestGetSurveys()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var service = new SurveyService(context);

				//Act
				List<Survey> surveysList = service.GetSurveys();

				//Assert
				Assert.Equal(context.Surveys, surveysList);
			}
		}

		[Fact]
		public void TestGetSurvey()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrage
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "6D4EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new SurveyService(context);

				//Act
				Survey survey = service.GetSurvey("6D4EBFCA6358ANHYE040EA75QWERT74C");

				//Assert
				Assert.Equal("6D4EBFCA6358ANHYE040EA75QWERT74C", survey.SurveyKey);
				Assert.Equal("Jon", survey.AccountLogin);
				Assert.Equal("Jon`s survey", survey.Name);
			}
		}

		[Fact]
		public void TestUpdateSurvey()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "789EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}

			using (var context = new TietoFeedbackToolContext(options))
			{
				var service = new SurveyService(context);
				Survey survey = new Survey() { SurveyKey = "789EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon's speciall survey" };

				//Act
				service.UpdateSurvey("789EBFCA6358ANHYE040EA75QWERT74C", survey);
				context.SaveChanges();

				//Assert
				Assert.Equal("789EBFCA6358ANHYE040EA75QWERT74C", context.Surveys.Find("789EBFCA6358ANHYE040EA75QWERT74C").SurveyKey);
				Assert.Equal("Jon", context.Surveys.Find("789EBFCA6358ANHYE040EA75QWERT74C").AccountLogin);
				Assert.Equal("Jon's speciall survey", context.Surveys.Find("789EBFCA6358ANHYE040EA75QWERT74C").Name);
			}
		}
	}
}
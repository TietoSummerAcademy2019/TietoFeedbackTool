using Xunit;
using TietoJar.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TietoJar.Persistence;
using TietoJar.Infrastructure.Services;
using System.Linq;

namespace TietoJar.Test
{
	[Collection("SurveyColletion")]
	public class SurveyServiceTestInMemory
	{
		public SurveyServiceTestInMemory() { }

		[Fact]
		public void TestAddSurvey()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;
			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "6D4EBFCA6358A3B4E040EA75POL6E74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				//Act
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}
			//Assert
			using (var context = new TietoJarContext(options))
			{
				var service = new SurveyService(context);
				Survey survey = service.GetSurvey("6D4EBFCA6358A3B4E040EA75POL6E74C");
				Assert.Equal("6D4EBFCA6358A3B4E040EA75POL6E74C", survey.SurveyKey);
				Assert.Equal("Jon", survey.AccountLogin);
				Assert.Equal("Jon`s survey", survey.Name);
			}
		}

		[Fact]
		public void TestGetSurveys()
		{
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "6D4EBFCA6358A3B4E040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };

				//Act
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}

			using (var context = new TietoJarContext(options))
			{
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
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrage
			using (var context = new TietoJarContext(options))
			{
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "6D4EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}

			using (var context = new TietoJarContext(options))
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
			var options = new DbContextOptionsBuilder<TietoJarContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			//Arrange
			using (var context = new TietoJarContext(options))
			{
				//Arrange
				var service = new SurveyService(context);
				Survey newSurvey = new Survey() { SurveyKey = "789EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon`s survey" };
				//Act
				service.AddSurvey(newSurvey);
				context.SaveChanges();
			}

			using (var context = new TietoJarContext(options))
			{
				var service = new SurveyService(context);
				Survey survey = new Survey() { SurveyKey = "789EBFCA6358ANHYE040EA75QWERT74C", AccountLogin = "Jon", Name = "Jon's speciall survey" };

				//Act
				service.UpdateSurvey("789EBFCA6358ANHYE040EA75QWERT74C", survey);
				context.SaveChanges();

				//Assert
				Assert.Equal("789EBFCA6358ANHYE040EA75QWERT74C", survey.SurveyKey);
				Assert.Equal("Jon", survey.AccountLogin);
				Assert.Equal("Jon's speciall survey", survey.Name);
			}
		}
	}
}

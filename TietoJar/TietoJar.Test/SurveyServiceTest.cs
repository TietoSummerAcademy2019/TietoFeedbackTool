using Xunit;
using TietoJar.Domain;
using System.Collections.Generic;

namespace TietoJar.Test
{
	[Collection("SurveyColletion")]
	public class SurveyServiceTest
	{
		TestSurveyDatabase DB;

		public SurveyServiceTest(TestSurveyDatabase DB)
		{
			this.DB = DB;
		}

		[Fact]
		public void TestAddSurvey()
		{
			//Arrange
			int expected = 3;
			Survey survey = new Survey { SurveyKey = "6D4EBFCA6358A3B4E040EA75B516E74C", AccountLogin = "Jon", Name = "Jon`s survey" };

			//Act
			DB.surveyService.AddSurvey(survey);
			int accountsNumberAfter = DB.surveyService.GetSurveys().Count;

			//Assert
			Assert.Equal(expected, accountsNumberAfter);
		}

		[Fact]
		public void TestGetSurveys()
		{
			//Arrange

			//Act
			List<Survey> surveys = DB.surveyService.GetSurveys();

			//Assert
			Assert.Equal(DB.surveys, surveys);
		}
	}
}
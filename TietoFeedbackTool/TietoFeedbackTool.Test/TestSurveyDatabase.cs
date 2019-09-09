using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;
using TietoFeedbackTool.Infrastructure.Services;
using Xunit;

namespace TietoFeedbackTool.Test
{
	public class TestSurveyDatabase : IDisposable
	{
		public List<Survey> surveys { get; private set; }

		public Mock<DbSet<Survey>> surveysMock { get; private set; }

		public Mock<ITietoFeedbackToolContext> tietoContextMock { get; private set; }

		public SurveyRepository surveyRepository { get; private set; }

		public TestSurveyDatabase()
		{
			surveys = new List<Survey>
			{
				new Survey { SurveyKey = "006CB570ACDAB0E0BFC8E3DCB7BB4EDF" , AccountLogin ="Jon" , Name="Jon`s special survey" },
				new Survey { SurveyKey = "21232F297A57A5A743894A0E4A801FC3" , AccountLogin ="admin" , Name="admin`s survey" },
			};

			surveysMock = new Mock<DbSet<Survey>>();
			surveysMock.As<IEnumerable<Survey>>().Setup(m => m.GetEnumerator()).Returns(() => surveys.GetEnumerator());
			surveysMock.Setup(d => d.Add(It.IsAny<Survey>())).Callback<Survey>((s) => surveys.Add(s));
			tietoContextMock = new Mock<ITietoFeedbackToolContext>();

			tietoContextMock.Setup(x => x.Surveys).Returns(surveysMock.Object);
			surveyRepository = new SurveyRepository(tietoContextMock.Object);
		}

		public void Dispose()
		{

		}
	}

	[CollectionDefinition("SurveyColletion")]
	public class SurveyDAtabaseColletion1 : ICollectionFixture<TestSurveyDatabase>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}
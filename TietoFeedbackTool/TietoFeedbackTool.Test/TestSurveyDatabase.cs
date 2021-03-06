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
	public class TestQuestionDatabase : IDisposable
	{
		public List<Question> surveys { get; private set; }

		public Mock<DbSet<Question>> surveysMock { get; private set; }

		public Mock<ITietoFeedbackToolContext> tietoContextMock { get; private set; }

		public QuestionRepository surveyRepository { get; private set; }


		public TestQuestionDatabase()
		{
			surveys = new List<Question>
			{
				new Question { AccountLogin ="Jon" , Domain="truboboost.com" ,QuestionText = "do you like me ?" , Enabled=true},
				new Question { AccountLogin ="Jon" , Domain="jonDoe.pl" , QuestionText = "do you like feedbacktool?" , Enabled=false},
			};

			surveysMock = new Mock<DbSet<Question>>();
			surveysMock.As<IEnumerable<Question>>().Setup(m => m.GetEnumerator()).Returns(() => surveys.GetEnumerator());
			surveysMock.Setup(d => d.Add(It.IsAny<Question>())).Callback<Question>((s) => surveys.Add(s));
			tietoContextMock = new Mock<ITietoFeedbackToolContext>();

			tietoContextMock.Setup(x => x.Question).Returns(surveysMock.Object);
			surveyRepository = new QuestionRepository(tietoContextMock.Object);
		}

		public void Dispose()
		{

		}
	}

	[CollectionDefinition("QuestionColletion")]
	public class QuestionDatabaseColletion1 : ICollectionFixture<TestQuestionDatabase>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Domain;
using TietoFeedbackTool.Infrastructure.Services;
using TietoFeedbackTool.Persistence;
using Xunit;

namespace TietoFeedbackTool.Test
{
	[Collection("TrackigCodeColletion")]
	public class TrackingCodeRepositoryTestInMemory
	{
		public TrackingCodeRepositoryTestInMemory() { }

		[Fact]
		public void Get_SingleAccountByQuestionKey_Returns_SameAccount()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Cesar", Name = "Juliusz Cesar" };
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
				var accountByQuestionKey = unitOfWork.TrackingCode.GetByString(account.QuestionsKey);
				var exptected = unitOfWork.Account.Find(x => x.QuestionsKey == account.QuestionsKey).SingleOrDefault();
				Assert.Equal(exptected, accountByQuestionKey);
				unitOfWork.Dispose();
				;
			}
		}

		[Fact]
		public void Get_ListOFQuestionByQuestionKeyAndDomain_Returns_SameList()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Jaskier", Name = "Julian Alfred Pankratz wicehrabia de Lettenhove" };
				var questions = new List<Question>
				{
					new Question { Id = 1, AccountLogin = "Jaskier", Domain = "localhost:44444", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question { Id = 2, AccountLogin = "Jaskier", Domain = "localhost:44350", QuestionText = "Are you free tonight?", Enabled = true },
					new Question { Id = 3, AccountLogin = "Jaskier", Domain = "localhost:44350", QuestionText = "Wanna go out for beer?", Enabled = true }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Jaskier");
				var cokolwiek = unitOfWork.TrackingCode.GetSurveyByDomain(account.QuestionsKey, "localhost:44350");
				var expected = unitOfWork.Question.GetAll().Where(x => x.Domain == "localhost:44350").ToList();
				Assert.Equal(expected, cokolwiek);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_HTMLTemplate_Returns_HTMLTemplate()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "InMemoryDB")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Zoltan", Name = "Zoltan Chivay" };
				var questions = new List<Question>
				{
					new Question { Id = 1, AccountLogin = "Zoltan", Domain = "localhost:44444", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question { Id = 2, AccountLogin = "Zoltan", Domain = "localhost:44350", QuestionText = "Are you free tonight?", Enabled = true },
					new Question { Id = 3, AccountLogin = "Zoltan", Domain = "localhost:44350", QuestionText = "Wanna go out for beer?", Enabled = true }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var trackingCodeRepository = new TrackingCodeRepository(context);
				var account = unitOfWork.Account.GetByString("Zoltan");
				//var loxd = trackingCodeRepository.CustomizeTemplate();
				//var xdlol = trackingCodeRepository.GetSurveyHtml
				var cokolwiek = unitOfWork.TrackingCode.GetSurveyHtml(account.QuestionsKey);
				var accountByQuestionKey = unitOfWork.TrackingCode.GetByString(account.QuestionsKey);
				var exptected = unitOfWork.Account.Find(x => x.QuestionsKey == account.QuestionsKey).SingleOrDefault();
				Assert.Equal(exptected, accountByQuestionKey);
				unitOfWork.Dispose();
				;
			}
		}
	}
}

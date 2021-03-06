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
							.UseInMemoryDatabase(databaseName: "Get_SingleAccountByQuestionKey_Returns_SameAccount")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Vilgefortz", Name = "Master Vilgefortz" };
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Vilgefortz");
				var accountByQuestionKey = unitOfWork.TrackingCode.GetByString(account.QuestionsKey);
				var exptected = unitOfWork.Account.Find(x => x.QuestionsKey == account.QuestionsKey).SingleOrDefault();
				Assert.Equal(exptected, accountByQuestionKey);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_ListOFQuestionByQuestionKeyAndDomain_Returns_SameList()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_ListOFQuestionByQuestionKeyAndDomain_Returns_SameList")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Jaskier", Name = "Julian Alfred Pankratz wicehrabia de Lettenhove" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Jaskier", Domain = "localhost:12645", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Jaskier", Domain = "localhost:12745", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Jaskier", Domain = "localhost:12845", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var surveyByDomain = unitOfWork.TrackingCode.GetSurveyByDomain(account.QuestionsKey, "localhost:12745");
				var expected = account.Questions.Where(x => x.Domain == "localhost:12745").ToList();
				Assert.Equal(expected, surveyByDomain);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_HTMLTemplate_Returns_TrueIfFindHTMLTemplate()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_HTMLTemplate_Returns_TrueIfFindHTMLTemplate")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Zoltan", Name = "Zoltan Chivay" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Zoltan", Domain = "localhost:19345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Zoltan", Domain = "localhost:12445", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Zoltan", Domain = "localhost:12545", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var account = unitOfWork.Account.GetByString("Zoltan");
				var path = @"../../../../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				var HTMLTemplate = unitOfWork.TrackingCode.GetSurveyHtml(account.QuestionsKey, path);
				Assert.NotNull(HTMLTemplate);
				Assert.Contains("btn feedback-marking-bar-button", HTMLTemplate);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_CSSTemplate_Returns_TrueIfFindCSSTemplate()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_CSSTemplate_Returns_TrueIfFindCSSTemplate")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Yarpen", Name = "Yarpen Zigrin" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Yarpen", Domain = "localhost:16345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Yarpen", Domain = "localhost:17345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Yarpen", Domain = "localhost:18345", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var account = unitOfWork.Account.GetByString("Yarpen");
				var path = @"../../../../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.css";
				var CSSTemplate = unitOfWork.TrackingCode.GetSurveyCSS(path);
				Assert.NotNull(CSSTemplate);
				Assert.Contains("background-image: url(../../../assets/img/exit.svg)", CSSTemplate);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_Script_Returns_TrueIfFinScript()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_Script_Returns_TrueIfFinScript")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Triss", Name = "Triss Merigold" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Triss", Domain = "localhost:13345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Triss", Domain = "localhost:14345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Triss", Domain = "localhost:15345", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var account = unitOfWork.Account.GetByString("Triss");
				var path = @"../../../../TietoFeedbackTool/ClientApp/src/assets/scripts/userSideScript.js";
				var Script = unitOfWork.TrackingCode.GetScript(account.QuestionsKey, path);
				Assert.NotNull(Script);
				Assert.Contains("function checkDomain()", Script);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_SurveyHtmlWithDomain_Returns_TrueIfFindSurveyHTML()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_SurveyHtmlWithDomain_Returns_TrueIfFindSurveyHTML")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Yennefer", Name = "Yennefer z Vengerbergu" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:72345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:82345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:92345", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var account = unitOfWork.Account.GetByString("Yennefer");
				var path = @"../../../../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				var HTMLTemplate = unitOfWork.TrackingCode.GetSurveyHtmlWithDomain(account.QuestionsKey, account.Questions[1].Domain, path);
				Assert.NotNull(HTMLTemplate);
				Assert.Contains("btn feedback-marking-bar-button", HTMLTemplate);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_DummySurveyHtml_Returns_TrueIfFindSurveyHTML()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_DummySurveyHtml_Returns_TrueIfFindSurveyHTML")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Yennefer", Name = "Yennefer z Vengerbergu" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:72345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:82345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Yennefer", Domain = "localhost:92345", QuestionText = "Wanna go out for beer?", Enabled = true }
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
				var account = unitOfWork.Account.GetByString("Yennefer");
				var question = unitOfWork.Question.Get(account.Questions[0].Id);
				var path_html = @"../../../../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				var path_script = @"../../../../TietoFeedbackTool/ClientApp/src/assets/scripts/dummyScript.js";
				var dummyHTML = unitOfWork.TrackingCode.GetDummySurveyHtml(path_html, question);
				var dummyScript = unitOfWork.TrackingCode.GetDummyScript(path_script, question);
				Assert.NotNull(dummyHTML);
				Assert.NotNull(dummyScript);
				Assert.Contains("btn feedback-marking-bar-button" , dummyHTML);
				Assert.Contains("function checkDomain()", dummyScript);
				unitOfWork.Dispose();
			}
		}
	}
}
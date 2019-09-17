using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Domain;
using TietoFeedbackTool.Infrastructure.Services;
using TietoFeedbackTool.Persistence;
using Xunit;

namespace TietoFeedbackTool.Test
{
	[Collection("OpenAnswerColletion")]
	public class OpenAnswerRepositoryTestInMemory
	{
		public OpenAnswerRepositoryTestInMemory() { }

		[Fact]
		public void Add_SingleAnswer_Returns_SameAnswer()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Add_SingleAnswer_Returns_SameAnswer")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Filippa", Name = "Filippa Eilhart" };
				Question newQuestion = new Question { AccountLogin = "Filippa", Domain = "localhost:44444", QuestionText = "Do You like feedbacktool?", Enabled = true };
				OpenPuzzleAnswer newOpenPuzzleAnswer = new OpenPuzzleAnswer() { QuestionId = 11, Answer = "Yes" };
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.Add(newQuestion);
				unitOfWork.OpenPuzzleAnswer.Add(newOpenPuzzleAnswer);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Filippa");
				var answer = account.Questions[0].OpenPuzzleAnswers[0];
				Assert.Equal("Yes", answer.Answer);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_ListOfAllAnswers_Returns_SameList()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_ListOfAllAnswers_Returns_SameList")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Sabrina", Name = "Sabrina Glevissig z Ard Carraigh" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Sabrina", Domain = "localhost:12345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Sabrina", Domain = "localhost:22345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Sabrina", Domain = "localhost:32345", QuestionText = "Wanna go out for beer?", Enabled = true }
				};
				var anserws = new List<OpenPuzzleAnswer>
				{
					new OpenPuzzleAnswer() { QuestionId = 1, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 1, Answer = "No" },
					new OpenPuzzleAnswer() { QuestionId = 2, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 2, Answer = "No" },
					new OpenPuzzleAnswer() { QuestionId = 3, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 3, Answer = "No" }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.OpenPuzzleAnswer.AddRange(anserws);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answers = unitOfWork.OpenPuzzleAnswer.GetAll();
				var expected = context.OpenPuzzleAnswers;
				Assert.Equal(expected, answers);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_ListOfAllAnswersRelatedToOneAccount_Returns_SameList()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_ListOfAllAnswersRelatedToOneAccount_Returns_SameList")
							.Options;

			using (var context = new TietoFeedbackToolContext(options))
			{
				//Arrange
				var unitOfWork = new UnitOfWork(context);
				Account newAccount = new Account() { Login = "Sheala", Name = "Sheala de Tancarville" };
				var questions = new List<Question>
				{
					new Question {  AccountLogin = "Sheala", Domain = "localhost:42345", QuestionText = "Do You like feedbacktool?", Enabled = true },
					new Question {  AccountLogin = "Sheala", Domain = "localhost:52345", QuestionText = "Are you free tonight?", Enabled = true },
					new Question {  AccountLogin = "Sheala", Domain = "localhost:62345", QuestionText = "Wanna go out for beer?", Enabled = true }
				};
				var anserws = new List<OpenPuzzleAnswer>
				{
					new OpenPuzzleAnswer() { QuestionId = 1, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 1, Answer = "No" },
					new OpenPuzzleAnswer() { QuestionId = 2, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 2, Answer = "No" },
					new OpenPuzzleAnswer() { QuestionId = 3, Answer = "Yes" },
					new OpenPuzzleAnswer() { QuestionId = 3, Answer = "No" }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.OpenPuzzleAnswer.AddRange(anserws);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answers = unitOfWork.OpenPuzzleAnswer.GetAll().Where(x => x.QuestionId == 1);
				var expected = context.OpenPuzzleAnswers.Where(x => x.QuestionId == 1);
				Assert.Equal(expected, answers);
				unitOfWork.Dispose();
			}
		}
	}
}
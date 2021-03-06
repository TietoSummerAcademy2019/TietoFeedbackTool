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
	public class PuzzleAnswerRepositoryTestInMemory
	{
		public PuzzleAnswerRepositoryTestInMemory() { }

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
				unitOfWork.Account.Add(newAccount);
				Question newQuestion = new Question { AccountLogin = "Filippa", Domain = "localhost:44444", QuestionText = "Do You like feedbacktool?", Enabled = true };
				unitOfWork.Question.Add(newQuestion);
				var accid = newAccount.Questions[0].Id;
				PuzzleAnswer newOpenPuzzleAnswer = new PuzzleAnswer() { QuestionId = accid, Answer = "Yes" };
				unitOfWork.PuzzleAnswer.Add(newOpenPuzzleAnswer);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var account = unitOfWork.Account.GetByString("Filippa");
				var answer = account.Questions[0].PuzzleAnswers[0];
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
				var answers = new List<PuzzleAnswer>
				{
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" },
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" },
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.PuzzleAnswer.AddRange(answers);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answers = unitOfWork.PuzzleAnswer.GetAll();
				var expected = context.PuzzleAnswers;
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
				var answers = new List<PuzzleAnswer>
				{
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" },
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" },
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" },
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" }
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.PuzzleAnswer.AddRange(answers);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answers = unitOfWork.PuzzleAnswer.GetAll().Where(x => x.QuestionId == 1);
				var expected = context.PuzzleAnswers.Where(x => x.QuestionId == 1);
				Assert.Equal(expected, answers);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_AnswerRatingRepetitions_Returns_TrueIfFindAnyAndReturnsIntendedValue()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_AnswersByRatingAndQuestionID_Returns_TrueIfFindAny")
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
				var answers = new List<PuzzleAnswer>
				{
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 3 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3}
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.PuzzleAnswer.AddRange(answers);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answerRatingList = unitOfWork.PuzzleAnswer.GetAnswerRatingRepetitions(1, 3);
				Assert.Equal(12, answerRatingList);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_AnswerRating_Returns_TrueIfFindAnyAndIfReturnsIntendedValue()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_AnswerRatingRepeating_Returns_TrueIfFindAnyAndIfReturnsIntendedValue")
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
				var answers = new List<PuzzleAnswer>
				{
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 3 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3}
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.PuzzleAnswer.AddRange(answers);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answersRating = unitOfWork.PuzzleAnswer.GetAnswerRating(1);
				Assert.NotNull(answersRating);
				Assert.Equal(8, answersRating.Count);
				unitOfWork.Dispose();
			}
		}

		[Fact]
		public void Get_AnswerRatingList_Returns_TrueIfFindAnyAndIfReturnsIntendedValue()
		{
			var options = new DbContextOptionsBuilder<TietoFeedbackToolContext>()
							.UseInMemoryDatabase(databaseName: "Get_AnswerRatingList_Returns_TrueIfFindAnyAndIfReturnsIntendedValue")
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
				var answers = new List<PuzzleAnswer>
				{
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 3 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "Yes", Rating = 1 },
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 1, Answer = "No" , Rating = 5},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 2, Answer = "Yes" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 2, Answer = "No" , Rating = 4},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "Yes" , Rating = 2},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3},
					new PuzzleAnswer() { QuestionId = 3, Answer = "No" , Rating = 3}
				};
				//Act
				unitOfWork.Account.Add(newAccount);
				unitOfWork.Question.AddRange(questions);
				unitOfWork.PuzzleAnswer.AddRange(answers);
				unitOfWork.Complete();
				unitOfWork.Dispose();
			}
			//Assert
			using (var context = new TietoFeedbackToolContext(options))
			{
				var unitOfWork = new UnitOfWork(context);
				var answersRatingList = unitOfWork.PuzzleAnswer.GetAnswerRatingList(1);
				Assert.NotNull(answersRatingList);
				Assert.Equal(4, answersRatingList[0]);
				Assert.Equal(3, answersRatingList[1]);
				Assert.Equal(2, answersRatingList[2]);
				Assert.Equal(7, answersRatingList[3]);
				Assert.Equal(2, answersRatingList[4]);

				unitOfWork.Dispose();
			}
		}
	}
}
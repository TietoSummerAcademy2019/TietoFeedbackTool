//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using TietoJar.Domain;

namespace TietoJar.Application.Interfaces
{
	public interface ITietoJarContext
	{
		//IDbSet<Account> Accounts { get; set; }
		//IDbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		//IDbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		//IDbSet<PuzzleType> PuzzleTypes { get; set; }
		//IDbSet<Survey> Surveys { get; set; }
		//IDbSet<SurveyPuzzle> SurveyPuzzles { get; set; }
		DbSet<Account> Accounts { get; set; }
		DbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		DbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		DbSet<PuzzleType> PuzzleTypes { get; set; }
		DbSet<Survey> Surveys { get; set; }
		DbSet<SurveyPuzzle> SurveyPuzzles { get; set; }

		int SaveChanges();
	}
}

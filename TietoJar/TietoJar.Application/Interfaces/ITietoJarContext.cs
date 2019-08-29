using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TietoJar.Domain;

namespace TietoJar.Application.Interfaces
{
	public interface ITietoJarContext
	{
		DbSet<Account> Accounts { get; set; }
		DbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		DbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		DbSet<PuzzleType> PuzzleTypes { get; set; }
		DbSet<Survey> Surveys { get; set; }
		DbSet<SurveyPuzzle> SurveyPuzzles { get; set; }
		DbSet<ClosePuzzleAnswer> ClosePuzzleAnswers { get; set; }
		int SaveChanges();
	}
}

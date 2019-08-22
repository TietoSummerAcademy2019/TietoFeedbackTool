using Microsoft.EntityFrameworkCore;
using TietoJar.Domain;

namespace TietoJar.Persistence
{
	public class TietoJarContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		public DbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		public DbSet<PuzzleType> PuzzleTypes { get; set; }
		public DbSet<Survey> Surveys { get; set; }
		public DbSet<SurveyPuzzle> SurveyPuzzles { get; set; }

		public TietoJarContext(DbContextOptions<TietoJarContext> options) : base(options)
		{

		}

	}
}

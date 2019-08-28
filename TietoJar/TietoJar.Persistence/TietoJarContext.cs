using Microsoft.EntityFrameworkCore;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;

namespace TietoJar.Persistence
{
	public class TietoJarContext : DbContext, ITietoJarContext
	{
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		public virtual DbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		public virtual DbSet<PuzzleType> PuzzleTypes { get; set; }
		public virtual DbSet<Survey> Surveys { get; set; }
		public virtual DbSet<SurveyPuzzle> SurveyPuzzles { get; set; }

		public TietoJarContext(DbContextOptions<TietoJarContext> options) : base(options)
		{

		}
	}
}

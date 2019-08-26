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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>().HasData(
				new Account
				{
					Login = "kangorooAdmin1",
					Name = "Kangaroo",
					Password = "zaq1xsw2"
				}
			);
			modelBuilder.Entity<Survey>().HasData(
				new Survey
				{
					SurveyKey = "123456789",
					AccountLogin = "kangorooAdmin1",
					Name = "defaultSurvey"
				}
			);

			modelBuilder.Entity<PuzzleType>().HasData(
				new PuzzleType
				{
					Id = 1,
					Name = "Stars",
					HaveOpenAnswer = true
				}
			);
			modelBuilder.Entity<SurveyPuzzle>().HasData(
				new SurveyPuzzle
				{
					Id = 1,
					PuzzleTypeId = 1,
					SurveyKey = "123456789",
					PuzzleQuestion = "Will it work?",
					Position = 1
				}
			);
			modelBuilder.Entity<OpenPuzzleAnswer>().HasData(
				new OpenPuzzleAnswer
				{
					Id = 1,
					SurveyPuzzleId = 1,
					Answer = "Yes, of course"
				}
			);
		}

	}
}

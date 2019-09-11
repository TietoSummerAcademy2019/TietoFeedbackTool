using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Persistence
{
	public class TietoFeedbackToolContext : DbContext, ITietoFeedbackToolContext
	{
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<ClosePuzzlePossibility> ClosePuzzlePossibilities { get; set; }
		public virtual DbSet<OpenPuzzleAnswer> OpenPuzzleAnswers { get; set; }
		public virtual DbSet<PuzzleType> PuzzleTypes { get; set; }
		public virtual DbSet<Survey> Surveys { get; set; }
		public virtual DbSet<SurveyPuzzle> SurveyPuzzles { get; set; }
		public virtual DbSet<ClosePuzzleAnswer> ClosePuzzleAnswers { get; set; }

		public TietoFeedbackToolContext(DbContextOptions<TietoFeedbackToolContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Account>()
				.HasIndex(u => u.QuestionKey)
				.IsUnique();
		}


		public TietoFeedbackToolContext() 
		{
		}
	}
}
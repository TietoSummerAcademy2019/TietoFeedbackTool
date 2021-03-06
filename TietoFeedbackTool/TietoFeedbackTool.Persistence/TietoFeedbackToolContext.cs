using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Persistence
{
	public class TietoFeedbackToolContext : DbContext, ITietoFeedbackToolContext
	{
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<PuzzleAnswer> PuzzleAnswers { get; set; }
		public virtual DbSet<Question> Question { get; set; }

		public TietoFeedbackToolContext(DbContextOptions<TietoFeedbackToolContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Account>()
				.HasIndex(u => u.QuestionsKey)
				.IsUnique();
		}


		public TietoFeedbackToolContext()
		{
		}
	}
}
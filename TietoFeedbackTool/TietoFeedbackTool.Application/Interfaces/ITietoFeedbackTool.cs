using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ITietoFeedbackToolContext
	{
		DbSet<Account> Accounts { get; set; }
		DbSet<PuzzleAnswer> PuzzleAnswers { get; set; }
		DbSet<Question> Question { get; set; }
		int SaveChanges();
		DbSet<T> Set<T>() where T : class;
	}
}

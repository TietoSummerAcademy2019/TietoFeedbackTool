using Microsoft.EntityFrameworkCore;
using TietoJar.Domain;

namespace TietoJar.Persistence
{
	public class AccountsContext: DbContext
	{
		public DbSet<Account> Accounts { get; set; }

		public AccountsContext(DbContextOptions<AccountsContext> options): base(options)
		{

		}

	}
}

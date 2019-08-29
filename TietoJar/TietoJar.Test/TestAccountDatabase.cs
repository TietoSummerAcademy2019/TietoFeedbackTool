namespace TietoJar.Test
{
	public class TestAccountDatabase : IDisposable
	{
		public List<Account> accounts { get; private set; }

		public Mock<DbSet<Account>> accountsMock { get; private set; }

		public Mock<ITietoJarContext> tietoContextMock { get; private set; } 

		public AccountService accountService { get; private set; }

		public TestAccountDatabase()
		{
			accounts = new List<Account>
			{
				new Account { Login = "Hollywood" , Name="Richard" , Password="6934c4368e77e0a4e6008ae5c16fcd5d" },
				new Account { Login = "PanPaweł" , Name="Paweł" , Password="d9729feb74992cc3482b350163a1a010" },
			};

			accountsMock = new Mock<DbSet<Account>>();
			accountsMock.As<IEnumerable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => accounts.GetEnumerator());
			accountsMock.Setup(d => d.Add(It.IsAny<Account>())).Callback<Account>((s) => accounts.Add(s));
			tietoContextMock = new Mock<ITietoJarContext>();

			tietoContextMock.Setup(x => x.Accounts).Returns(accountsMock.Object);
			accountService = new AccountService(tietoContextMock.Object);
		}

		public void Dispose()
		{
			
		}
	}

	[CollectionDefinition("AccountColletion")]
	public class AccountDAtabaseColletion1 : ICollectionFixture<TestAccountDatabase>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}
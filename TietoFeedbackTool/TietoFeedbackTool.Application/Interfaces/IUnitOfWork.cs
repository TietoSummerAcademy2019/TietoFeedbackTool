using System;
using System.Collections.Generic;
using System.Text;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IAccountService Account { get; }
		int Complete();
	}
}

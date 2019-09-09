using System;
using System.Collections.Generic;
using System.Text;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IDomainRepository: IRepository<Survey>
	{
		List<string> GetDomains();
		string GetDomain(string domain);
	}
}
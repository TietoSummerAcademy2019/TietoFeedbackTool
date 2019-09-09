using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class DomainRepository: Repository<Survey>, IDomainRepository
	{
		public DomainRepository(ITietoFeedbackToolContext context) : base(context)
		{

		}
		public List<string> GetDomains()
		{
			var surveys = _context.Surveys.ToList();
			List<string> domains = surveys.Select(item => item.Domain).ToList();
			return domains;
		}

		public string GetDomain(string domain)
		{
			var _survey = _context.Surveys.Where(x => x.Domain == domain).SingleOrDefault();
			if (_survey != null)
			{
				return _survey.Domain;
			}
			else
			{
				return null;
			}
		}
	}
}
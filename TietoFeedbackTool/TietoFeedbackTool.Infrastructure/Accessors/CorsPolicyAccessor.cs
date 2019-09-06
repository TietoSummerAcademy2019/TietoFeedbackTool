using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using TietoFeedbackTool.Application.Interfaces;

namespace TietoFeedbackTool.Infrastructure.Accessors
{
	public class CorsPolicyAccessor : ICorsPolicyAccessor
	{
		private readonly CorsOptions _options;

		public CorsPolicyAccessor(IOptions<CorsOptions> options)
		{
			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}
			_options = options.Value;
		}

		public CorsPolicy GetPolicy()
		{
			return _options.GetPolicy("_myAllowSpecificOrigins");
		}

		public CorsPolicy GetPolicy(string name)
		{
			return _options.GetPolicy(name);
		}
	}
}

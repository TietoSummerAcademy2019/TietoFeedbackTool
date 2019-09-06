using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface ICorsPolicyAccessor
	{
		CorsPolicy GetPolicy();
		CorsPolicy GetPolicy(string name);
	}
}

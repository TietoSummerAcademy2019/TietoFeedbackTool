using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class TrackingCodeRepository : Repository<Account>, ITrackingCodeRepository
	{
		public TrackingCodeRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public Account GetSurvey(string questionKey)
		{
			return _context.Accounts.Include(x => x.Questions).SingleOrDefault(x => x.QuestionsKey == questionKey);
		}

		public string GetSurveyHtmlWithDomain(string key, string domain)
		{
			var survey = GetSurveyByDomain(key, domain);

			if (survey != null)
			{
				string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				return CustomizeTemplate(LoadFile(scriptPath), survey);
			}
			return null;
		}

		public string GetSurveyHtml(string key)
		{
			var survey = GetSurvey(key);

			if (survey != null)
			{
				string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				return CustomizeTemplate(LoadFile(scriptPath), survey.Questions);
			}
			return null;
		}

		public List<Question> GetSurveyByDomain(string questionKey, string domain)
		{
			Account user = _context.Accounts.Include(x => x.Questions).SingleOrDefault(x => x.QuestionsKey == questionKey);
			List<Question> questions = user.Questions.Where(x => x.Domain == domain).ToList();
			return questions;
		}

		public string GetSurveyCSS()
		{
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.css";
			return LoadFile(scriptPath);
		}

		public string LoadFile(string path)
		{
			if (File.Exists(path))
			{
				using (StreamReader sr = new StreamReader(path))
				{
					return sr.ReadToEnd();
				}
			}
			return null;
		}

		public string CustomizeTemplate(string HTMLTemaplte, List<Question> survey)
		{
			Question question = survey[0];
			var HTMLContent = new HtmlDocument();
			HTMLContent.LoadHtml(HTMLTemaplte);

			HTMLContent.GetElementbyId("question-text").InnerHtml = question.QuestionText;
			HTMLContent.GetElementbyId("answer").SetAttributeValue("data-id", question.Id.ToString());

			return HTMLContent.DocumentNode.OuterHtml;
		}

		public string GetScript(string surveyKey)
		{
			var survey = GetSurvey(surveyKey);

			if (survey != null)
			{
				StringBuilder script = new StringBuilder();
				string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/scripts/userSideScript.js";
				script.AppendLine("function  getSurveyKey(){ ");
				script.AppendLine($"return \"{surveyKey}\"");
				script.AppendLine("}");				
				script.AppendLine(LoadFile(scriptPath));

				return script.ToString();
			}
			else
			{
				return null;
			}			
		}
	}
}

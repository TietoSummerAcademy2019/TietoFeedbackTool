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

		public new Account GetByString(string questionKey)
		{
			return _context.Accounts.Include(x => x.Questions).SingleOrDefault(x => x.QuestionsKey == questionKey);
		}

		public string GetSurveyHtmlWithDomain(string key, string domain, string path)
		{
			var survey = GetSurveyByDomain(key, domain);

			if (survey != null)
			{
				return CustomizeTemplate(LoadFile(path), survey);
			}
			return null;
		}

		public string GetSurveyHtml(string key, string path)
		{
			var survey = GetByString(key);

			if (survey != null)
			{
				string scriptPath = path;
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

		public List<Question> GetQuestionsWithAnswersByDomaiName(string doaminName)
		{
			List<Question> question = _context.Question.Include(x => x.PuzzleAnswers).Where(x => x.DomainName == doaminName).ToList();
			return question;
		}

		public string GetDomainByDomainName(string domainName)
		{
			var domain = _context.Question.Where(x => x.DomainName == domainName).SingleOrDefault().Domain;
			return domain;
		}

		public string GetSurveyCSS(string path)
		{
			return LoadFile(path);
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
			List<Question> enabledQuestions = survey.Where(x => x.Enabled == true).ToList();

			if (enabledQuestions.Count == 0)
			{
				return null;
			}

			Question question = enabledQuestions.First();// change to handle more questions
			var HTMLContent = new HtmlDocument();
			HTMLContent.LoadHtml(HTMLTemaplte);

			HTMLContent.GetElementbyId("question-text").InnerHtml = question.QuestionText;
			HTMLContent.GetElementbyId("answer").SetAttributeValue("data-id", question.Id.ToString());

			return HTMLContent.DocumentNode.OuterHtml;
		}

		public string GetScript(string surveyKey, string path)
		{
			var survey = GetByString(surveyKey);

			if (survey != null)
			{
				StringBuilder script = new StringBuilder();
				script.AppendLine("function  getSurveyKey(){ ");
				script.AppendLine($"return \"{surveyKey}\"");
				script.AppendLine("}");
				script.AppendLine(LoadFile(path));
				return script.ToString();
			}
			else
			{
				return null;
			}
		}
	}
}
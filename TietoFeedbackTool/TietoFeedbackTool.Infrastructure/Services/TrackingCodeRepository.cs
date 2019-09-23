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

		public string GetDummySurveyHtml(string path, Question question)
		{ 
			List<Question> survey = new List<Question>();
			question.Enabled = true;
			survey.Add(question);
			return CustomizeTemplate(LoadFile(path), survey);
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

		public string GetSurveyCSS(string path)
		{
			return LoadFile(path);
		}

		private string LoadFile(string path)
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

			if (question.IsBottom == false)
			{
				HTMLContent.GetElementbyId("feedback-main").SetAttributeValue("data-isBottom", "false");
				HTMLContent.GetElementbyId("window-content").AddClass("width");
			}

			HtmlNode input;

			if (question.HasRating == false)
			{
				input = HtmlNode.CreateNode("<textarea class=\"answer-input align-self-center\" id=\"answer\" data-id=\"\"></textarea>");			
			}
			else
			{
				input = HtmlNode.CreateNode("<div id=\"answer\" data-id=\"\"></div>");
				input.AppendChild(HtmlNode.CreateNode( "<input type=\"radio\" name=\"new-answer\" value=\"1\">"));
				input.AppendChild(HtmlNode.CreateNode("<input type=\"radio\" name=\"new-answer\" value=\"2\">"));
				input.AppendChild(HtmlNode.CreateNode("<input type=\"radio\" name=\"new-answer\" value=\"3\">"));
				input.AppendChild(HtmlNode.CreateNode("<input type=\"radio\" name=\"new-answer\" value=\"4\">"));
				input.AppendChild(HtmlNode.CreateNode("<input type=\"radio\" name=\"new-answer\" value=\"5\">"));				
			}

			var node = HTMLContent.GetElementbyId("need");
			HTMLContent.GetElementbyId("answer-type-input").InnerHtml = input.OuterHtml ;
			HTMLContent.GetElementbyId("answer-type-input").AppendChild(node);

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

		public string GetDummyScript(string path, Question question)
		{
			StringBuilder toRet = new StringBuilder("");

			toRet.AppendLine("function getQuestion() {");
			toRet.AppendLine("var scriptData = {");
			toRet.AppendLine($"QuestionText: `{question.QuestionText}`,");
			toRet.AppendLine($"AccountLogin: `{question.AccountLogin}`,");
			toRet.AppendLine($"HasRating: `{question.HasRating}`,");
			toRet.AppendLine($"IsBottom: `{question.IsBottom}`,");
			toRet.AppendLine($"RatingType: `{question.RatingType}`");
			toRet.AppendLine("};");
			toRet.AppendLine("return JSON.stringify(scriptData);");
			toRet.AppendLine("}");

			toRet.AppendLine(LoadFile(path));
			return toRet.ToString();
		}
	}
}
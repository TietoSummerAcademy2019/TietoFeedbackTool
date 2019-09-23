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
				if(question.RatingType == "Numbers")
				{
					input = numbers();
				}else if(question.RatingType == "Smiles")
				{
					input = smiles();
				}
				else
				{
					input = stars();
				}
			}
			//var nodes = HTMLContent.GetElementbyId("answer-type-input").ChildNodes;
			//HTMLContent.DocumentNode.InsertBefore(input, HTMLContent.GetElementbyId("answer-type-input").ChildNodes[1]);
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

		public string GetDummyScript(string path)
		{
			return LoadFile(path);
		}

		public HtmlNode stars()
		{
			StringBuilder node = new StringBuilder();


			HtmlNode input;
			input = HtmlNode.CreateNode("<div id=\"answer\" data-id=\"\"></div>");

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"1\" class='inv'>");
			node.Append(" <img class='star' name='starImage' onclick='markStars(1)'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='star' name='starImage' onclick='markStars(2)'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='star' name='starImage' onclick='markStars(3)'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='star' name='starImage' onclick='markStars(4)'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='star' name='starImage' onclick='markStars(5)'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();
			return input;
		}


		public HtmlNode smiles()
		{

			StringBuilder node = new StringBuilder();


			HtmlNode input;
			input = HtmlNode.CreateNode("<div id=\"answer\" data-id=\"\"></div>");

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"1\" class='inv'>");
			node.Append(" <img class='smile'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='smile'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='smile'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='smile'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='smile'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();
			return input;
		}

		public HtmlNode numbers()
		{

			StringBuilder node = new StringBuilder();


			HtmlNode input;
			input = HtmlNode.CreateNode("<div id=\"answer\" data-id=\"\"></div>");

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"1\" class='inv'>");
			node.Append(" <img class='number'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='number'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='number'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='number'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='number'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();
			return input;
		}
	}
}


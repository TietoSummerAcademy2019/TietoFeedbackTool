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
	/// <summary>
	/// Repository contains handlig method of question collection, creating feedback tool html and installation function.
	/// </summary>
	public class TrackingCodeRepository : Repository<Account>, ITrackingCodeRepository
	{
		public TrackingCodeRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		/// <summary>
		/// Modified method from basic repository.
		/// Get account and all related question by questionKey.
		/// </summary>
		/// <param name="questionKey">Account QuestionKey</param>
		/// <returns>Specific account.</returns>
		public new Account GetByString(string questionKey)
		{
			return _context.Accounts.Include(x => x.Questions).SingleOrDefault(x => x.QuestionsKey == questionKey);
		}

		/// <summary>
		/// Get feedback tool html for specific domain.
		/// Check if question with such domain exist.
		/// </summary>
		/// <param name="key">Account QuestionKey</param>
		/// <param name="domain">Question domain</param>
		/// <param name="path">path to html template</param>
		/// <returns>Feedback tool html.</returns>
		public string GetSurveyHtmlWithDomain(string key, string domain, string path)
		{
			var survey = GetSurveyByDomain(key, domain);

			if (survey != null)
			{
				return CustomizeTemplate(LoadFile(path), survey);
			}
			return null;
		}

		/// <summary>
		/// Get dummy feedback tool html for preview.
		/// </summary>
		/// <param name="path">path to html template</param>
		/// <param name="question">Dummy Question: question</param>
		/// <returns>Html</returns>
		public string GetDummySurveyHtml(string path, Question question)
		{ 
			List<Question> survey = new List<Question>();
			question.Enabled = true;
			survey.Add(question);
			return CustomizeTemplate(LoadFile(path), survey);
		}

		/// <summary>
		/// Get base feedback tool html.
		/// Check if account exist.
		/// </summary>
		/// <param name="key">Account QuestionKey</param>
		/// <param name="path">path to html template</param>
		/// <returns>String contains html file.</returns>
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

		/// <summary>
		/// Get list of question related to specyfic domain.
		/// </summary>
		/// <param name="questionKey">Account QuestionKey</param>
		/// <param name="domain">Question domain</param>
		/// <returns>List of question.</returns>
		public List<Question> GetSurveyByDomain(string questionKey, string domain)
		{
			Account user = _context.Accounts.Include(x => x.Questions).SingleOrDefault(x => x.QuestionsKey == questionKey);
			List<Question> questions = user.Questions.Where(x => x.Domain == domain).ToList();
			return questions;
		}

		/// <summary>
		/// Get css of feedback tool from file.
		/// </summary>
		/// <param name="path">path to css file.</param>
		/// <returns>Css style</returns>
		public string GetSurveyCSS(string path)
		{
			return LoadFile(path);
		}

		/// <summary>
		/// Check if file with given path exist, and use streamreader to read this file.
		/// </summary>
		/// <param name="path">path to file.</param>
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

		/// <summary>
		/// Create feedback tool html.
		/// Check if question exist.
		/// Handlig question if is bottom option is true.
		/// </summary>
		/// <param name="HTMLTemaplte"></param>
		/// <param name="survey"></param>
		/// <returns></returns>
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
			var node = HTMLContent.GetElementbyId("need");
			HTMLContent.GetElementbyId("answer-type-input").InnerHtml = input.OuterHtml ;
			HTMLContent.GetElementbyId("answer-type-input").AppendChild(node);

			HTMLContent.GetElementbyId("question-text").InnerHtml = question.QuestionText;
			HTMLContent.GetElementbyId("answer").SetAttributeValue("data-id", question.Id.ToString());

			return HTMLContent.DocumentNode.OuterHtml;
		}

		/// <summary>
		/// Create script for installing feedback tool.
		/// </summary>
		/// <param name="surveyKey"></param>
		/// <param name="path"></param>
		/// <returns>Installation function.</returns>
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

		/// <summary>
		/// Create preview installing script.
		/// </summary>
		/// <param name="path"></param>
		/// <returns>Dummy installing script.</returns>	
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

		public HtmlNode stars()
		{
			StringBuilder node = new StringBuilder();


			HtmlNode input;
			input = HtmlNode.CreateNode("<div id=\"answer\" data-id=\"\"></div>");

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"1\" class='inv'>");
			node.Append(" <img class='star tool-img' name='starImage' onmouseover='markStars(1)' onmouseleave='getBackSelectedStar()'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='star tool-img' name='starImage' onmouseover='markStars(2)' onmouseleave='getBackSelectedStar()'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='star tool-img' name='starImage' onmouseover='markStars(3)' onmouseleave='getBackSelectedStar()'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='star tool-img' name='starImage' onmouseover='markStars(4)' onmouseleave='getBackSelectedStar()'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='star tool-img' name='starImage' onmouseover='markStars(5)' onmouseleave='getBackSelectedStar()'> ");
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
			node.Append(" <img class='smile tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='smile tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='smile tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='smile tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='smile tool-img'> ");
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
			node.Append(" <img class='number tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"2\" class='inv'>");
			node.Append(" <img class='number tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"3\" class='inv'>");
			node.Append(" <img class='number tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"4\" class='inv'>");
			node.Append(" <img class='number tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();

			node.Append("<label>");
			node.Append("<input type=\"radio\" name=\"new-answer\" value=\"5\" class='inv'>");
			node.Append(" <img class='number tool-img'> ");
			node.Append("</label>");

			input.AppendChild(HtmlNode.CreateNode(node.ToString()));
			node.Clear();
			return input;
		}
	}
}
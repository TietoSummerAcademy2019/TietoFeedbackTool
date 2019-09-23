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

			HTMLContent.GetElementbyId("question-text").InnerHtml = question.QuestionText;
			HTMLContent.GetElementbyId("answer").SetAttributeValue("data-id", question.Id.ToString());

			if (question.IsBottom == false)
			{
				HTMLContent.GetElementbyId("feedback-main").SetAttributeValue("data-isBottom", "false");
				HTMLContent.GetElementbyId("window-content").AddClass("width");
			}

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
		public string GetDummyScript(string path)
		{
			return LoadFile(path);
		}
	}
}
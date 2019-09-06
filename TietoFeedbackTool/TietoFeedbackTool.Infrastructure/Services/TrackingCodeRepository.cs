using System.IO;
using System.Linq;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class TrackingCodeRepository : Repository<Survey>, ITrackingCodeRepository
	{
		public TrackingCodeRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}
		public Survey GetSurvey(string surveyKey)
		{
			return _context.Surveys.Include(x => x.SurveyPuzzles).SingleOrDefault(x => x.SurveyKey == surveyKey);
		}
		public string GetSurveyHtml(string key)
		{
			var survey = GetSurvey(key);

			if (survey != null)
			{
				string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.html";
				return CustomizeTemplate(LoadFile(scriptPath),survey);
			}
			return null;
		}

		public string GetSurveySCSS()
		{
			string scriptPath = @"../TietoFeedbackTool/ClientApp/src/assets/surveyPuzzleTemplates/markingBar.scss";
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

		public string CustomizeTemplate(string HTMLTemaplte, Survey survey)
		{
			SurveyPuzzle puzzle = survey.SurveyPuzzles[0];
			var HTMLContent = new HtmlDocument();
			HTMLContent.LoadHtml(HTMLTemaplte);

			HTMLContent.GetElementbyId("question-text").InnerHtml = puzzle.PuzzleQuestion;
			HTMLContent.GetElementbyId("answer").SetAttributeValue("data-id", puzzle.Id.ToString());

			return HTMLContent.DocumentNode.OuterHtml;
		}
	}
}

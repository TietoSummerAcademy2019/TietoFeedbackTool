using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface ISurveyService
    {
        //Survey
        List<Survey> GetSurveys();
        Survey AddSurvey(Survey survey);
        Survey GetSurvey(string surveyKey);
        Survey UpdateSurvey(string surveyKey, Survey survey);
        void DeleteSurvey(string surveyKey);
		Account GetSurveysWithQuestions(string login);
		//SurveyPuzzle
		SurveyPuzzle AddSurveyPuzzle(SurveyPuzzle surveyPuzzle);
        List<SurveyPuzzle> GetSurveyPuzzles();
        SurveyPuzzle GetSurveyPuzzle(int id);
        SurveyPuzzle UpdateSurveyPuzzle(int id, SurveyPuzzle surveyPuzzle);
        void DeleteSurveyPuzzle(int id);
        //PuzzleType
        PuzzleType AddPuzzleType(PuzzleType puzzleType);
        List<PuzzleType> GetPuzzleTypes();
        PuzzleType GetPuzzleType(int id);
        PuzzleType UpdatePuzzleType(int id, PuzzleType puzzleType);
        void DeletePuzzleType(int id);
		string GetSurveyHtml(string key);
		string GetSurveySCSS();
	}
}
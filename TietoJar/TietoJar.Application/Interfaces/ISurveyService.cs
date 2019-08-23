using System.Collections.Generic;
using TietoJar.Domain;

namespace TietoJar.Application.Interfaces
{
    public interface ISurveyService
    {
        List<Survey> GetSurveys();
        Survey AddSurvey(Survey survey);
        Survey GetSurvey(int id);
        Survey UpdateSurvey(int id, Survey survey);
        void DeleteSurvey(int id);
        SurveyPuzzle AddSurveyPuzzle(SurveyPuzzle surveyPuzzle);
        List<SurveyPuzzle> GetSurveyPuzzles();
    }
}
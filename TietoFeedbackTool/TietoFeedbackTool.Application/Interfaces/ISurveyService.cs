using System.Collections.Generic;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Application.Interfaces
{
    public interface ISurveyService : IRepository<Survey>
    {
		//Survey
		Account GetSurveysWithQuestions(string login);
		//SurveyPuzzle
		
        //PuzzleType
        
    }
}
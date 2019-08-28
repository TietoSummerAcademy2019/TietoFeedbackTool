using System;
using System.Text;
using System.Collections.Generic;
using TietoJar.Domain;

namespace TietoJar.Application.Interfaces
{
	public interface IAnswerService
	{
		//OpenPuzzleAnswer
		OpenPuzzleAnswer AddOpenPuzzleAnswer(OpenPuzzleAnswer openPuzzleAnswer);
        List<OpenPuzzleAnswer> GetOpenPuzzleAnswers();
		List<OpenPuzzleAnswer> GetOpenPuzzleAnswers(int id);
		//ClosePuzzleAnswer
		ClosePuzzlePossibility AddClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility);
        List<ClosePuzzlePossibility> GetClosePuzzlePossibilities();
		List<ClosePuzzlePossibility> GetClosePuzzlePossibilities(int id);
		ClosePuzzlePossibility GetClosePuzzlePossibility(int SurveyPuzzleId, int position, string answer);
		ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility);
    }
}

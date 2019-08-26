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
        //ClosePuzzleAnswer
        ClosePuzzlePossibility AddClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility);
        List<ClosePuzzlePossibility> GetClosePuzzlePossibilities();
		ClosePuzzlePossibility GetClosePuzzlePossibility(int puzzleId, int position, string answer);
		ClosePuzzlePossibility UpdateClosePuzzlePossibility(ClosePuzzlePossibility closePuzzlePossibility);
    }
}

import { OpenPuzzleAnswer } from './OpenPuzzleAnswer';

export interface SurveyPuzzles {
  id: number;
  puzzleTypeId: number;
  surveyKey: string;
  puzzleQuestion: string;
  position: number;
  openPuzzleAnswers: OpenPuzzleAnswer[];
}
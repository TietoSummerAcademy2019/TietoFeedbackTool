import { OpenPuzzleAnswer } from './OpenPuzzleAnswer';

export interface SurveyPuzzle {
  id: number;
  puzzleTypeId: number;
  surveyKey: string;
  puzzleQuestion: string;
  position: number;
  openPuzzleAnswer: OpenPuzzleAnswer[];
}
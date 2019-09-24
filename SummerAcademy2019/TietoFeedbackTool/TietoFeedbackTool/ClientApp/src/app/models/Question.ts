import { PuzzleAnswer } from './OpenPuzzleAnswer';

export interface Question {
  id?: number;
  domain: string;
  questionText: string;
  AccountLogin: string;
  puzzleAnswers?: PuzzleAnswer[];
  enabled: boolean;
  hasRating: boolean;
  isBottom: boolean;
  ratingType: string;
}
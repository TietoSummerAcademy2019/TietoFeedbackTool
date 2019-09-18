import { PuzzleAnswer } from './OpenPuzzleAnswer';

export interface Question {
  id?: number;
  Domain: string;
  questionText: string;
  AccountLogin: string;
  puzzleAnswers?: PuzzleAnswer[];
  enabled: boolean;
  name: string;
  hasRating: boolean;
  isBottom: boolean;
  ratingType: string;
}
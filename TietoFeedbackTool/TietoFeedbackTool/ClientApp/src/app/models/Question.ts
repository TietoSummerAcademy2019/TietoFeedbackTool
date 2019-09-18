import { OpenPuzzleAnswer } from './OpenPuzzleAnswer';

export interface Question {
  id?: number;
  Domain: string;
  questionText: string;
  AccountLogin: string;
  openPuzzleAnswers?: OpenPuzzleAnswer[];
  enabled: boolean;
  isBottom: boolean;
}
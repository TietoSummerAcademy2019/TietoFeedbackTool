import { OpenPuzzleAnswer } from './OpenPuzzleAnswer';

export interface Question {
  Domain: string;
  questionText: string;
  AccountLogin: string;
  openPuzzleAnswers?: OpenPuzzleAnswer[];
  enabled: boolean;
}
import { Question } from './Question';

export interface Account {
  login: string;
  name: string;
  questionsKey: string
  questions?: Question[];
}
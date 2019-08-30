import { SurveyPuzzle } from './SurveyPuzzle';

export interface Survey {
  surveyKey: string;
  accountLogin: string;
  name: string;
  SurveyPuzzle: SurveyPuzzle[];
}

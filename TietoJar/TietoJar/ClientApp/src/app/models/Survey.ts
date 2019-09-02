import { SurveyPuzzles } from './SurveyPuzzles';

export interface Survey {
  surveyKey: string;
  accountLogin: string;
  name: string;
  surveyPuzzles: SurveyPuzzles[];
}
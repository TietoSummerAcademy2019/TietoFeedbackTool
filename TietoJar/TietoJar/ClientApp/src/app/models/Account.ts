import { Survey } from './Survey';

export interface Account {
  login: string;
  name: string;
  password: string;
  surveys: Survey[];
}
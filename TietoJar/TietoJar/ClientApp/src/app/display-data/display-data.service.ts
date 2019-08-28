import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { environment } from '../../environments/environment';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class DisplayDataService<T extends SurveyPuzzle, F extends OpenPuzzleAnswer> {

  private readonly urlQuestion = environment.newQuestionUrl;
  private readonly urlAnswer = environment.openAnswerUrl;

  constructor(private http: HttpClient) {}

  public getQuestions(): Observable<T[]> {
    return this.http.get<T[]>(this.urlQuestion);
  }

  public getAnswers(): Observable<F[]> {
    return this.http.get<F[]>(this.urlAnswer);
  }
}

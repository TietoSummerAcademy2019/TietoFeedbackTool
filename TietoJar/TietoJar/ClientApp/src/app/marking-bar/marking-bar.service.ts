import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OpenAnswer } from '../models/OpenAnswer';

@Injectable({
  providedIn: 'root'
})
export class MarkingBarService<T extends SurveyPuzzle, X extends OpenAnswer>{
  private items: T[] = [];
  private readonly apiBase = environment.newQuestionUrl;
  private readonly answerApi = environment.openAnswerUrl;

  constructor(private http: HttpClient) {
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
      });
  }

  getQuestion(): string {
    console.log(this.items);
    return this.items[0].puzzleQuestion;
  }

  addAnswer(item: X) {
    this.http.post(this.answerApi, item).subscribe();
  }
}
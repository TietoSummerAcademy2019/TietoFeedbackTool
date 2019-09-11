import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OpenAnswer } from '../models/OpenAnswer';
import { Question } from '../models/Question';

@Injectable({
  providedIn: 'root'
})
export class MarkingBarService<T extends Question, X extends OpenAnswer>{
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
    return this.items[0].questionText;
  }

  addAnswer(item: X) {
    console.log(item);
    this.http.post(this.answerApi, item).subscribe();
  }
}
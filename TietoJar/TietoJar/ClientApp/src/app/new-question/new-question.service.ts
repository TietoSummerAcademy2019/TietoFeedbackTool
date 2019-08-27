import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewQuestionService<T extends SurveyPuzzle> {

  private items: T[] = [];
  private readonly apiBase = environment.apiBaseUrl;

  constructor(private http: HttpClient) {
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
        // for loop for demo purpose
        for(let item of items) {
          console.log(item.puzzleQuestion)
        }
    });
  }

  add(item: T): void {
    this.items.push(item);
    this.http.post(this.apiBase, item)
      .subscribe(
        () => {}
    );
  }
}
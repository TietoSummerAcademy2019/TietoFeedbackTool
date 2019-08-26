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
  // apiBaseUrl to be used when backend is ready
  private readonly apiBase = environment.apiBaseUrl;
  // list to be used for filtering questions if they are meant not to repeat
  // private items$ = new BehaviorSubject<T[]>([]);

  constructor(private http: HttpClient) {
    // http get to instantly see if there are any errors
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
        // this.items$.next(this.items);
        // iterate through the array of extracted objects and see the previously entered values
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

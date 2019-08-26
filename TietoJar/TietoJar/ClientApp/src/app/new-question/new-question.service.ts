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
  private items$ = new BehaviorSubject<T[]>([]);

  constructor(private http: HttpClient) { }

  add(item: T): void {
    this.items.push(item);
    this.http.post(this.apiBase, item)
      .subscribe(
        () => {},
        // () => {
        //   this.items = this.items.filter(({id}) => item.id !== id);
        //   this.items$.next(this.items);
        // }
    );
    console.log(this.items.find(i => i.puzzleQuestion));
  }
}

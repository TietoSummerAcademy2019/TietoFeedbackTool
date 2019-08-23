import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/question';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewQuestionService<T extends Question> {

  private items: T[] = [];
  private readonly apiBase = environment.apiBaseUrl;
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
  }
}

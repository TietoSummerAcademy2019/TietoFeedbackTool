import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/Question';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewQuestionService<T extends Question> {

  private items: T[] = [];
  private readonly apiBase = environment.newQuestionUrl;

  constructor(private http: HttpClient) {
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
    });
  }

  getItems() {
    return this.http.get<T>(this.apiBase).toPromise();
  }

  add(item: T) {
    this.items.push(item);
    this.http.post(this.apiBase, item).subscribe();
  }
}
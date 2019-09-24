import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Question } from '../models/Question';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewQuestionService<T extends Question> {

  private items: T[] = [];
  private response: HttpResponse<T>;
  private readonly apiBase = environment.newQuestionUrl;
  private readonly updateUrl = environment.updateQuestionUrl;
  private dummyScriptUrl = environment.dummyscriptUrl;

  constructor(private http: HttpClient) {
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
      });
  }

  getItems() {
    return this.http.get<T>(this.apiBase).toPromise();
  }

  async getDummyScript(question: Question) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = {
      headers: headers,
      observe: "response" as 'body',
      responseType: "text" as "json"
    };

    return this.http.post<HttpResponse<any>>(this.dummyScriptUrl, question, options).toPromise();
  }

  add(item: T) {
    this.items.push(item);
    this.http.post(this.apiBase, item).subscribe();
  }

  updateQuestion(id: number, question: T) {
    this.http.put(`${this.updateUrl}/${id}`, question).subscribe()
  }
}
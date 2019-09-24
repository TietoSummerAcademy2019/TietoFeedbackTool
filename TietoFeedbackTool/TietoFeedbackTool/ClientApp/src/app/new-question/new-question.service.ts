import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/Question';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpResponse} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class NewQuestionService<T extends Question> {

  private items: T[] = [];
  private readonly apiBase = environment.newQuestionUrl;
  private readonly updateUrl = environment.updateQuestionUrl;

  constructor(private http: HttpClient) {
    this.http.get<T[]>(this.apiBase)
      .subscribe(items => {
        this.items = items;
    });
  }

  getItems() {
    return this.http.get<T>(this.apiBase).toPromise();
  }

  getDummyScript(question: Question) {
    let headers = new HttpHeaders;
    let options = {
      headers: headers,
      observe: "response" as 'body',
      responseType: "text" as "json"
    };

    return this.http.post<HttpResponse<any>>(this.dummyScriptUrl, question, options).subscribe(response => {
      console.log(response.body);
    });
  }

  add(item: T) {
    this.items.push(item);
    this.http.post(this.apiBase, item).subscribe();
  }

  updateQuestion(id: number, question: T) {
    this.http.put(`${this.updateUrl}/${id}`, question).subscribe()
  }
}
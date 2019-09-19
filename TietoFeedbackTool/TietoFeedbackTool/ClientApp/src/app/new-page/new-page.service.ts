import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/Question';

@Injectable({
  providedIn: 'root'
})
export class NewPageService<T extends Question> {

  private readonly newPageUrl = environment.newPageUrl;

  constructor(private http: HttpClient) {
  }

  addPage(item: T) {
    this.http.post(this.newPageUrl, item).subscribe();
  }
}

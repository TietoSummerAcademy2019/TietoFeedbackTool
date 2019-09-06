import { Injectable } from '@angular/core';
import { Survey } from '../models/Survey';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrackingCodeGenerationService<T extends Survey> {

  public surveys: T[] = [];
  private readonly apiUrl = environment.surveyUrl;

  constructor(private http: HttpClient) { }

  public getSurveys() {
    return this.http.get<T>(this.apiUrl).toPromise();
  }
}

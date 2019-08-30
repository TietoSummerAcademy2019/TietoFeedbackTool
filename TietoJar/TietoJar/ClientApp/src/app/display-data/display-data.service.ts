import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { Observable } from 'rxjs';
import { map, merge } from 'rxjs/operators';
import { Survey } from '../models/Survey';


@Injectable({
  providedIn: 'root'
})
export class DisplayDataService<T extends Survey> {

  private readonly dataByLoginUrl = environment.dataByLoginUrl;

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Survey>(this.dataByLoginUrl).subscribe();
  }

}

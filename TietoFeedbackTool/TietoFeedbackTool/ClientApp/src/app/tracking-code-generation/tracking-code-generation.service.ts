import { Injectable } from '@angular/core';
import { Account } from '../models/Account';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrackingCodeGenerationService<T extends Account> {

  public surveys: T[] = [];
  private readonly apiUrl = environment.accountUrl;

  constructor(private http: HttpClient) { }

  public getAccounts() {
    return this.http.get<T>(this.apiUrl).toPromise();
  }
}

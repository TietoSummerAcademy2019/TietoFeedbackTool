import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { map, merge } from 'rxjs/operators';
import { Account } from '../models/Account';


@Injectable({
  providedIn: 'root'
})
export class DisplayDataService<T extends Account> {

  private readonly dataByLoginUrl = environment.dataByLoginUrl;

  constructor(private http: HttpClient) {}

  // getAll() {
  //   return this.http.get(this.dataByLoginUrl).toPromise();
  // }

  public getAll() {
    return this.http.get<T[]>(this.dataByLoginUrl).toPromise();
  }

}

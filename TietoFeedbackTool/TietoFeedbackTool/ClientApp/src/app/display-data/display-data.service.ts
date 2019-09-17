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
  private readonly deleteQuestionUrl = environment.deleteQuestionUrl;
  private readonly updateQuestionEnabledUrl = environment.updateQuestionEnabledUrl;

  constructor(private http: HttpClient) {}

  public getAll() {
    return this.http.get<T>(this.dataByLoginUrl).toPromise();
  }


  remove(id:string) {
    this.http.delete(`${this.deleteQuestionUrl}/${id}`).subscribe();
    window.location.reload();
  }

  updateEnabled(id:string, enabledIs: boolean) {
    console.log(`${this.updateQuestionEnabledUrl}/${id}/${enabledIs}`)
    //this.http.put(`${this.updateQuestionEnabledUrl}/${id}/${enabledIs}`)
  }

}
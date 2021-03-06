import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Account } from '../models/Account';


@Injectable({
  providedIn: 'root'
})
export class DisplayDataService<T extends Account> {

  private readonly dataByLoginUrl = environment.dataByLoginUrl;
  private readonly deleteQuestionUrl = environment.deleteQuestionUrl;
  private readonly updateQuestionEnabledUrl = environment.updateQuestionEnabledUrl;
  private readonly domainsUrl = environment.domainsUrl;
  private readonly getRatingUrl = environment.getRatingUrl;

  constructor(private http: HttpClient) {}

  public getAll() {
    return this.http.get<T>(this.dataByLoginUrl).toPromise();
  }

  getDomains() {
    return this.http.get<string[]>(this.domainsUrl).toPromise();
  }

  remove(id:string) {
    this.http.delete(`${this.deleteQuestionUrl}/${id}`).subscribe();
    window.location.reload();
  }

  updateEnabled(id:string, enabledIs: boolean) {
    this.http.put(`${this.updateQuestionEnabledUrl}/${id}/${enabledIs}`, null)
    .subscribe(
      data => console.log('success', data),
      error => console.log('oops', error)
    );
  }

  getRating(idQuestion: number){
    console.log(`${this.getRatingUrl}/${idQuestion}`)
    return this.http.get(`${this.getRatingUrl}/${idQuestion}`).toPromise();
  }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TranslateService {

  data: any = {};

language: string;

constructor(private http: HttpClient) { }

use(lang: string): Promise<{}> {
  return new Promise<{}>((resolve, reject) => {
    const langPath = `assets/${lang || 'fi'}.json`;
    this.http.get<{}>(langPath).subscribe(
      translation => {
        this.data = Object.assign({}, translation || {});
        resolve(this.data);
        this.language = this.data.lang;
      },
      error => {
        console.log('Error');
      }
    );
  });
}

}

import { Component } from '@angular/core';
import { TranslateService } from './translate-service/translate-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tieto Jar';
  team = 'Team Kangaroo';
  languages: Object = [
    {id: 'en', name: "English"},
    {id: 'fi', name: "Suomi"}
  ];
  // language: string;
  selectedLanguage: string;

  constructor(private translate: TranslateService) {
    this.selectedLanguage = this.translate.language;
   }

  setLang(lang: string) {
    this.selectedLanguage = this.translate.language;
    this.translate.use(lang);
  }
}
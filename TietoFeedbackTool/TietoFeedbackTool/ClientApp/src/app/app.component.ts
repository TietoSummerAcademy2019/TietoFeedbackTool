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
  selectedLanguage: string;

  constructor(private translate: TranslateService) {
    this.selectedLanguage = "English";
  }


  setLang(lang: string, langName: string) {
    this.translate.use(lang);
    this.selectedLanguage = langName;
    console.log(langName);
  }
}
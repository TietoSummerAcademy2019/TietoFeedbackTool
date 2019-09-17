import { Component } from '@angular/core';
import { TranslateService } from './translate-service/translate-service.service';
import { Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tieto FeedBackTool';
  selectedLanguage: string;
  image: string = 'url(../assets/flags-eng.svg)';
  imageNavbar: string;
  imageNavbar_1 = '../assets/img/ninjakangoogeometric.png';
  imageNavbar_2 = '../assets/img/back.svg';

  constructor(private translate: TranslateService, private router: Router) {
    this.selectedLanguage = "English";

    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        if (event.url === '/') {
          this.imageNavbar = this.imageNavbar_1;
          document.getElementById('icon').classList.add('kangaroo-icon');
          document.getElementById('icon').classList.remove('icon-back');
        } else {
          this.imageNavbar = this.imageNavbar_2;
          document.getElementById('icon').classList.add('icon-back');
          document.getElementById('icon').classList.remove('kangaroo-icon');
        }
      }
    });
  }

  setLang(lang: string, langName: string) {
    if(lang == 'en') {
      this.image = 'url(../assets/flags-eng.svg)'
    }
    else {
      this.image = 'url(../assets/flags-fin.svg)'
    }
    this.translate.use(lang);
    this.selectedLanguage = langName;
  }
}
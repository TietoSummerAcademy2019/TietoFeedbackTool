import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { TranslatePipe } from '../app/translate-service/translate.pipe';
import { TranslateService } from '../app/translate-service/translate-service.service';
import { By } from '@angular/platform-browser';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let spyEvent;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [
        AppComponent,
        TranslatePipe
      ],
      providers: [
        TranslateService
      ]
    }).compileComponents();
  }));


  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should navbar exist', () => {
    const compiled = fixture.debugElement.nativeElement;
    expect(fixture.debugElement.query(By.css('.navigation-item'))).toBeTruthy();
  });

  it('should default language be english', () => {
    const button = fixture.debugElement.query(By.css('#dropdownMenuButton'));
    expect(button.nativeElement.textContent).toContain('English ');
  });

  it('should dropdown contain items', () => {
    const language = fixture.debugElement.query(By.css('.dropdown-item'));
    expect(language).toBeTruthy();
  });

  it('should dropdown item contain suomi language', () => {
    const language = fixture.debugElement.queryAll(By.css('.dropdown-item'));
    var a = '';
    for (var i = 0; i < language.length; i++) {
      a += language[i].nativeElement.textContent;
      a += ' ';
    }
    expect(a).toContain('Suomi');
  })

  it('should call function setlang on language item press', async(() => {
    let language = fixture.debugElement.query(By.css('.dropdown-item'));
   
    spyOn(component, 'setLang');
    language.nativeElement.click();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      expect(component.setLang).toHaveBeenCalled();
    });
  }));

  
});
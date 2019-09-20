/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { NewQuestionComponent } from './new-question.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { TranslateService } from '../translate-service/translate-service.service';
import { TranslatePipe } from '../translate-service/translate.pipe';
import { RouterModule } from '@angular/router';

describe('NewQuestionComponent', () => {
  let component: NewQuestionComponent;
  let fixture: ComponentFixture<NewQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [TranslateService],
      imports: [FormsModule, HttpClientTestingModule, RouterModule.forRoot([])],
      declarations: [NewQuestionComponent, TranslatePipe ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create new question component', () => {
    expect(component).toBeTruthy();
  });

  it('should p have some text', () => {
    fakeAsync(() => {
      const compiled = fixture.debugElement.nativeElement;
      expect(compiled.querySelector('p').textContent).toContain('Ask your site visitor about their opinion.');
    })
  });

  it('should run onsubmit after click', () => {
    fakeAsync(() => {
      let button = fixture.debugElement.queryAll(By.css('.submit'));
      spyOn(component, 'onSubmit');
      button[1].nativeElement.click();
      expect(component.onSubmit).toHaveBeenCalled();
    })
  })
});
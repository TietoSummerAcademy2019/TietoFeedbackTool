/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { NewQuestionComponent } from './new-question.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('NewQuestionComponent', () => {
  let component: NewQuestionComponent;
  let fixture: ComponentFixture<NewQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [],
      imports: [FormsModule, HttpClientTestingModule],
      declarations: [ NewQuestionComponent ]
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

  it('should p have some text',() => {
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('p').textContent).toContain('Ask your site visitor about their opinion.');
  });

  it('should run onsubmit after click', () => {
    let button = fixture.debugElement.queryAll(By.css('.tieto-button'));
    spyOn(component, 'onSubmit');
    button[1].nativeElement.click();
    expect(component.onSubmit).toHaveBeenCalled();
 
  })
});
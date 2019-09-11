import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayDataComponent } from './display-data.component';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('DisplayDataComponent', () => {
  let component: DisplayDataComponent;
  let fixture: ComponentFixture<DisplayDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [
        HttpClient,
        HttpHandler
      ],
      declarations: [
        DisplayDataComponent
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });
  
});
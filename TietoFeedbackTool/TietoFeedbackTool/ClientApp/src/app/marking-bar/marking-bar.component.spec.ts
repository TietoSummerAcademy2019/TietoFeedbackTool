/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MarkingBarComponent } from './marking-bar.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('MarkingBarComponent', () => {
  let component: MarkingBarComponent;
  let fixture: ComponentFixture<MarkingBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientTestingModule],
      declarations: [ MarkingBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarkingBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    fakeAsync(() => {
      expect(component).toBeTruthy();
    })
  });
});
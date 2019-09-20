/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MarkingBarSideComponent } from './marking-bar-side.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('MarkingBarSideComponent', () => {
  let component: MarkingBarSideComponent;
  let fixture: ComponentFixture<MarkingBarSideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientTestingModule],
      declarations: [ MarkingBarSideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarkingBarSideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    fakeAsync(() => {
      expect(component).toBeTruthy();
    })
  });
});

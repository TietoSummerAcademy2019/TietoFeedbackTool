/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MarkingBarComponent } from './marking-bar.component';

describe('MarkingBarComponent', () => {
  let component: MarkingBarComponent;
  let fixture: ComponentFixture<MarkingBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
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
    expect(component).toBeTruthy();
  });
});

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { HttpClient, HttpHandler } from '@angular/common/http';

import { TrackingCodeGenerationComponent } from './tracking-code-generation.component';

describe('TrackingCodeGenerationComponent', () => {
  let component: TrackingCodeGenerationComponent;
  let fixture: ComponentFixture<TrackingCodeGenerationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient, HttpHandler],
      declarations: [TrackingCodeGenerationComponent]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackingCodeGenerationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
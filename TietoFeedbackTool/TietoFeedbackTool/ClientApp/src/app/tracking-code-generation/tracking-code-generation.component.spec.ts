/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { TrackingCodeGenerationComponent } from './tracking-code-generation.component';
import { TranslateService } from '../translate-service/translate-service.service';
import { TranslatePipe } from '../translate-service/translate.pipe';

describe('TrackingCodeGenerationComponent', () => {
  let component: TrackingCodeGenerationComponent;
  let fixture: ComponentFixture<TrackingCodeGenerationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TranslateService],
      declarations: [TrackingCodeGenerationComponent, TranslatePipe]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackingCodeGenerationComponent);
    component = fixture.componentInstance;
    return new Promise(function (resolve, reject) {
      component.init();
      resolve();
    });
  });

  it('should create tracking code generation component', () => {
    expect(component).toBeTruthy();
  });
});
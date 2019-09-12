/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { TrackingCodeGenerationComponent } from './tracking-code-generation.component';

describe('TrackingCodeGenerationComponent', () => {
  let component: TrackingCodeGenerationComponent;
  let fixture: ComponentFixture<TrackingCodeGenerationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [TrackingCodeGenerationComponent]
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


  /* TO BE FIXED
  it('should component have code to copy', function (done){
  
    return new Promise(function (resolve, reject) {
      component.init().then(function () {
        const copytext = fixture.debugElement.query(By.css('#text-copy'));
        expect(copytext.nativeElement.textContent).toContain("asd");
      } );
      resolve();
    });
  });
  */
});
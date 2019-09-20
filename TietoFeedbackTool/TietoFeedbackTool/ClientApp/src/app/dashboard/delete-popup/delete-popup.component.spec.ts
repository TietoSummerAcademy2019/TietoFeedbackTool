/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DeletePopupComponent } from './delete-popup.component';
import { TranslatePipe } from '../../translate-service/translate.pipe';
import { TranslateService } from '../../translate-service/translate-service.service';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

describe('DeletePopupComponent', () => {
  let component: DeletePopupComponent;
  let fixture: ComponentFixture<DeletePopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([])],
      providers: [
        TranslateService,
        HttpClient,
        HttpHandler,
        {
          provide: MatDialogRef,
          useValue: {}
        }, {
          provide: MAT_DIALOG_DATA,
          useValue: {}
        }
      ],
      declarations: [DeletePopupComponent, TranslatePipe ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletePopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
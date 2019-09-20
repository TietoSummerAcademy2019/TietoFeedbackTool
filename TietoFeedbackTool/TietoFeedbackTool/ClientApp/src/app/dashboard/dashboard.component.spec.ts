/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { TranslatePipe } from '../translate-service/translate.pipe';
import { TranslateService } from '../translate-service/translate-service.service';
import { DashboardComponent } from './dashboard.component';
import { AppRoutingModule } from '../app-routing.module';
import { NewQuestionComponent } from '../new-question/new-question.component';
import { DisplayDataComponent } from '../display-data/display-data.component';
import { MarkingBarComponent } from '../marking-bar/marking-bar.component';
import { MarkingBarSideComponent } from '../marking-bar-side/marking-bar-side.component';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        TranslatePipe,
        DashboardComponent,
        NewQuestionComponent,
        DisplayDataComponent,
        MarkingBarComponent,
        MarkingBarSideComponent
      ],
      imports: [AppRoutingModule],
      providers: [TranslateService]

    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
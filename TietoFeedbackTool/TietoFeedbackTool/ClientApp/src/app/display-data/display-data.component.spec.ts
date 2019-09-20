import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { By } from '@angular/platform-browser';
import { TranslatePipe } from '../translate-service/translate.pipe';
import { TranslateService } from '../translate-service/translate-service.service';
import { DisplayDataComponent } from './display-data.component';
import { ChartsModule } from 'ng2-charts';
import { RouterModule } from '@angular/router';

describe('DisplayDataComponent', () => {
  let component: DisplayDataComponent;
  let fixture: ComponentFixture<DisplayDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, ChartsModule, RouterModule.forRoot([])],
      providers: [TranslateService],
      declarations: [DisplayDataComponent, TranslatePipe ]
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

  it('should activeSite be 1', () => {
    expect(component.activeSite).toEqual(1);
  });

  it('should change activeSite to asigned one', () => {
    var site = 3;
    component.setActiveSite(site);
    expect(component.activeSite).toEqual(site);
  });

  it('shoud table be created', () => {
    const table = fixture.debugElement.query(By.css('.information-question-information'));
    expect(table).toBeTruthy();
  });
});
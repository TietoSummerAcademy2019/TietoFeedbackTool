import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MarkingBarService } from './marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('MarkingBarService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [HttpClient]
  }));

  it('should be created', () => {
    const service: MarkingBarService<SurveyPuzzle, OpenAnswer> = TestBed.get(MarkingBarService);
    expect(service).toBeTruthy();
  });
});
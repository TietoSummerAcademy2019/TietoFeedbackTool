import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MarkingBarService } from './marking-bar.service';
import { Question } from '../models/Question';
import { OpenAnswer } from '../models/OpenAnswer';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('MarkingBarService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: MarkingBarService<Question, OpenAnswer> = TestBed.get(MarkingBarService);
    expect(service).toBeTruthy();
  });
});
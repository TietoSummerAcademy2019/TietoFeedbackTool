/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DisplayDataService } from './display-data.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';

describe('Service: DisplayData', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DisplayDataService]
    });
  });

  it('should ...', inject([DisplayDataService], (service: DisplayDataService<SurveyPuzzle, OpenPuzzleAnswer>) => {
    expect(service).toBeTruthy();
  }));
});

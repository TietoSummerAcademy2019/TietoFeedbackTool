/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { Survey } from '../models/Survey';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('Service: TrackingCodeGeneration', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrackingCodeGenerationService, HttpClient, HttpHandler]
    });
  });

  it('should ...', inject([TrackingCodeGenerationService], (service: TrackingCodeGenerationService<Survey>) => {
    expect(service).toBeTruthy();
  }));
});

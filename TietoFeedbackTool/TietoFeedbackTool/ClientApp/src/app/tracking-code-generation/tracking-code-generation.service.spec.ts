/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { Account } from '../models/Account';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('Service: TrackingCodeGeneration', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrackingCodeGenerationService, HttpClient, HttpHandler]
    });
  });

  it('should create tracking code service', inject([TrackingCodeGenerationService], (service: TrackingCodeGenerationService<Account>) => {
    expect(service).toBeTruthy();
  }));
});

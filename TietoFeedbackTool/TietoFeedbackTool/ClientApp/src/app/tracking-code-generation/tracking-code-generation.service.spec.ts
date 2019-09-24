/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { Account } from '../models/Account';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('Service: TrackingCodeGeneration', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TrackingCodeGenerationService]
    });
  });

  it('should create tracking code service', inject([TrackingCodeGenerationService], (service: TrackingCodeGenerationService<Account>) => {
    expect(service).toBeTruthy();
  }));
});

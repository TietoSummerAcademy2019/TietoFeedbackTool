/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';

describe('Service: TrackingCodeGeneration', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrackingCodeGenerationService]
    });
  });

  it('should ...', inject([TrackingCodeGenerationService], (service: TrackingCodeGenerationService) => {
    expect(service).toBeTruthy();
  }));
});

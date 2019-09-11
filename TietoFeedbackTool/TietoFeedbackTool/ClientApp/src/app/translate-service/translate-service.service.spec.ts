/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TranslateService } from './translate-service.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('Service: TranslateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TranslateService]
    });
  });

  it('should ...', inject([TranslateService], (service: TranslateService) => {
    expect(service).toBeTruthy();
  }));
});
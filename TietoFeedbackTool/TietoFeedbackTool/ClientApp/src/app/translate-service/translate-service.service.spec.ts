/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TranslateService } from './translate-service.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient,HttpHandler } from '@angular/common/http';


describe('Service: TranslateService', () => {
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TranslateService, HttpClient, HttpHandler]
    });
  });

  it('should create translate service', inject([TranslateService], (service: TranslateService) => {
    expect(service).toBeTruthy();
  }));
});
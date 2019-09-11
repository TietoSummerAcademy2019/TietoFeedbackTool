/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DisplayDataService } from './display-data.service';
import { Survey } from '../models/Survey';
import { Account } from '../models/Account';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('Service: DisplayData', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        DisplayDataService,
        HttpClient,
        HttpHandler
      ]
    });
  });

  it('should ...', inject([DisplayDataService], (service: DisplayDataService<Account>) => {
    expect(service).toBeTruthy();
  }));
});
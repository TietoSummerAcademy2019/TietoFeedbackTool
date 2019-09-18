/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NewPageService } from './new-page.service';

describe('Service: NewPage', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NewPageService]
    });
  });

  it('should ...', inject([NewPageService], (service: NewPageService) => {
    expect(service).toBeTruthy();
  }));
});

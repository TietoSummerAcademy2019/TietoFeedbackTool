import { TestBed } from '@angular/core/testing';

import { MarkingBarService } from './marking-bar.service';

describe('MarkingBarService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MarkingBarService = TestBed.get(MarkingBarService);
    expect(service).toBeTruthy();
  });
});

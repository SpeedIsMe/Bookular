import { TestBed } from '@angular/core/testing';

import { BookularService } from './bookular.service';

describe('BookularService', () => {
  let service: BookularService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookularService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

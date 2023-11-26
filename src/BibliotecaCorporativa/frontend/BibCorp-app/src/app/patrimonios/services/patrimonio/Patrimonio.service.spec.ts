import { TestBed } from '@angular/core/testing';

import { PatrimonioService } from './patrimonio.service';

describe('PatrimonioService', () => {
  let service: PatrimonioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatrimonioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

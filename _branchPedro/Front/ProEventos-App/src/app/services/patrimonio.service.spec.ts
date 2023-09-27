/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PatrimonioService } from './patrimonio.service';

describe('Service: Patrimonio', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PatrimonioService]
    });
  });

  it('should ...', inject([PatrimonioService], (service: PatrimonioService) => {
    expect(service).toBeTruthy();
  }));
});

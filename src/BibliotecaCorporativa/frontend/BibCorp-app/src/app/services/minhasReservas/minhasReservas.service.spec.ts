/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MinhasReservasService } from './minhasReservas.service';

describe('Service: MinhasReservas', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MinhasReservasService]
    });
  });

  it('should ...', inject([MinhasReservasService], (service: MinhasReservasService) => {
    expect(service).toBeTruthy();
  }));
});

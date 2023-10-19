/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AcervoService } from './Acervo.service';

describe('Service: Acervo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AcervoService]
    });
  });

  it('should ...', inject([AcervoService], (service: AcervoService) => {
    expect(service).toBeTruthy();
  }));
});

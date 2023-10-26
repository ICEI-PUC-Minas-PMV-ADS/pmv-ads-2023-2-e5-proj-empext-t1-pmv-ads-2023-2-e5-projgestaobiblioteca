import { TestBed, inject } from '@angular/core/testing'
import { PatrimonioService } from './Patrimonio.service'

describe('Service: Acervo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PatrimonioService]
    })
  })

  it('should ...', inject([PatrimonioService], (service: PatrimonioService) => {
    expect(service).toBeTruthy()
  }))
})

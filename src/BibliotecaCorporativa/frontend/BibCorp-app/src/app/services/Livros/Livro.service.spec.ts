import { TestBed, inject } from '@angular/core/testing'
import { LivroService } from './Livro.service'

describe('Service: Acervo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LivroService]
    })
  })

  it('should ...', inject([LivroService], (service: LivroService) => {
    expect(service).toBeTruthy()
  }))
})

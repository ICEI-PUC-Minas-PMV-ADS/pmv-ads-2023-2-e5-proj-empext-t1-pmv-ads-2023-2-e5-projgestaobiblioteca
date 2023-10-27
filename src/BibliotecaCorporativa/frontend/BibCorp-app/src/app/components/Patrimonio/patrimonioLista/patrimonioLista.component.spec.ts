import { type ComponentFixture, TestBed } from '@angular/core/testing'
import { PatrimonioListaComponent } from './patrimonioLista.component'




describe('PatrimonioListaComponent', () => {
  let component: PatrimonioListaComponent
  let fixture: ComponentFixture<PatrimonioListaComponent>

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PatrimonioListaComponent]
    })
    fixture = TestBed.createComponent(PatrimonioListaComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})

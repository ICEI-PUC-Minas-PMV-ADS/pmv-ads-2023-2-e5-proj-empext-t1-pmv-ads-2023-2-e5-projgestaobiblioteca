import { async, type ComponentFixture, TestBed } from '@angular/core/testing'
import { PrincipalComponent } from './Principal.component'

describe('PrincipalComponent', () => {
  let component: PrincipalComponent
  let fixture: ComponentFixture<PrincipalComponent>

  beforeEach(async(() => {
    void TestBed.configureTestingModule({
      declarations: [PrincipalComponent]
    })
      .compileComponents()
  }))

  beforeEach(() => {
    fixture = TestBed.createComponent(PrincipalComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarSolicitacoesComponent } from './gerenciarSolicitacoes.component';

describe('GerenciarSolicitacoesComponent', () => {
  let component: GerenciarSolicitacoesComponent;
  let fixture: ComponentFixture<GerenciarSolicitacoesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GerenciarSolicitacoesComponent]
    });
    fixture = TestBed.createComponent(GerenciarSolicitacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

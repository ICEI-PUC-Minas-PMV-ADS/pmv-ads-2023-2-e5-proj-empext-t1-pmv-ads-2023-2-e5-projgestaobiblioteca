import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalSucessoComponent } from './modalSucesso.component';

describe('ModalSucessoComponent', () => {
  let component: ModalSucessoComponent;
  let fixture: ComponentFixture<ModalSucessoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalSucessoComponent]
    });
    fixture = TestBed.createComponent(ModalSucessoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

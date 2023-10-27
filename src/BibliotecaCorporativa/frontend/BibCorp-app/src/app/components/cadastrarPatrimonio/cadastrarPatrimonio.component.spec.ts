import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarPatrimonioComponent } from './cadastrarPatrimonio.component';

describe('CadastrarPatrimonioComponent', () => {
  let component: CadastrarPatrimonioComponent;
  let fixture: ComponentFixture<CadastrarPatrimonioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarPatrimonioComponent]
    });
    fixture = TestBed.createComponent(CadastrarPatrimonioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

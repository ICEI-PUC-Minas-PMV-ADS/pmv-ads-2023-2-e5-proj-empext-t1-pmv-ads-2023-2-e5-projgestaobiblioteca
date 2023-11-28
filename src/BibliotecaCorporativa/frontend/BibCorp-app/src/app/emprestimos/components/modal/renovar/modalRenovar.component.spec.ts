import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalRenovarComponent } from './modalRenovar.component';

describe('ModalRenovarComponent', () => {
  let component: ModalRenovarComponent;
  let fixture: ComponentFixture<ModalRenovarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalRenovarComponent]
    });
    fixture = TestBed.createComponent(ModalRenovarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

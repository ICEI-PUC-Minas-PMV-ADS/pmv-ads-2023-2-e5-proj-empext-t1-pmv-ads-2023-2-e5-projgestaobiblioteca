import { ComponentFixture, TestBed } from '@angular/core/testing';

import { modalEmprestarComponent } from './modalEmprestar.component';

describe('PopUpComponent', () => {
  let component: modalEmprestarComponent;
  let fixture: ComponentFixture<modalEmprestarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [modalEmprestarComponent]
    });
    fixture = TestBed.createComponent(modalEmprestarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

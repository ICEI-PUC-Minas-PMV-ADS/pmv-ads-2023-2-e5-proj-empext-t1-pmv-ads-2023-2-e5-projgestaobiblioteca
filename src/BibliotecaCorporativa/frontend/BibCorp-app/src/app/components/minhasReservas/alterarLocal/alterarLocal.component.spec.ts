import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarLocalComponent } from './alterarLocal.component';

describe('AlterarLocalComponent', () => {
  let component: AlterarLocalComponent;
  let fixture: ComponentFixture<AlterarLocalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarLocalComponent]
    });
    fixture = TestBed.createComponent(AlterarLocalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

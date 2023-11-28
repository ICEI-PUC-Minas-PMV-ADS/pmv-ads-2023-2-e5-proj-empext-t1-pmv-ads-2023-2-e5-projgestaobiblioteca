import { ComponentFixture, TestBed } from '@angular/core/testing';

import { homeAdminComponent } from './homeAdmin.component';

describe('HomeAdminComponent', () => {
  let component: homeAdminComponent;
  let fixture: ComponentFixture<homeAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [homeAdminComponent]
    });
    fixture = TestBed.createComponent(homeAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

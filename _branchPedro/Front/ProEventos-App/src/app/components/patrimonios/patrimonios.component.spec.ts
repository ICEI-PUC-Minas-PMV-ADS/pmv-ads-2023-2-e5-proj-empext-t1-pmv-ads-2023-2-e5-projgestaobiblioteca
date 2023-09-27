/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PatrimoniosComponent } from './patrimonios.component';

describe('PatrimoniosComponent', () => {
  let component: PatrimoniosComponent;
  let fixture: ComponentFixture<PatrimoniosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatrimoniosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatrimoniosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AcervoComponent } from './acervo.component';

describe('AcervoComponent', () => {
  let component: AcervoComponent;
  let fixture: ComponentFixture<AcervoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcervoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcervoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

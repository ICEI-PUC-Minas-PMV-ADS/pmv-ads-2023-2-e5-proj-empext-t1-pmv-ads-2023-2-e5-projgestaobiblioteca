import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VolumesComponent } from './volumes.component';

describe('VolumeComponent', () => {
  let component: VolumesComponent;
  let fixture: ComponentFixture<VolumesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VolumesComponent]
    });
    fixture = TestBed.createComponent(VolumesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

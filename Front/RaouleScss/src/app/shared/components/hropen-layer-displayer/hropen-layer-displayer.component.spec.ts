import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HROpenLayerDisplayerComponent } from './hropen-layer-displayer.component';

describe('HROpenLayerDisplayerComponent', () => {
  let component: HROpenLayerDisplayerComponent;
  let fixture: ComponentFixture<HROpenLayerDisplayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HROpenLayerDisplayerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HROpenLayerDisplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

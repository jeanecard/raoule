import { TestBed } from '@angular/core/testing';

import { HROpenLayerViewService } from './hropen-layer-view.service';

describe('HROpenLayerViewService', () => {
  let service: HROpenLayerViewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HROpenLayerViewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

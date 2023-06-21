/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RouteStateService } from './routeState.service';

describe('Service: RouteState', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RouteStateService]
    });
  });

  it('should ...', inject([RouteStateService], (service: RouteStateService) => {
    expect(service).toBeTruthy();
  }));
});

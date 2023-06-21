import { TestBed, async, inject } from '@angular/core/testing';

import { PreventUnsavedGuard } from './prevent-unsaved.guard';

describe('PreventUnsavedGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PreventUnsavedGuard]
    });
  });

  it('should ...', inject([PreventUnsavedGuard], (guard: PreventUnsavedGuard) => {
    expect(guard).toBeTruthy();
  }));
});

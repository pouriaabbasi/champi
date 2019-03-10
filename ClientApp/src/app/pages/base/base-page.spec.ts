import { TestBed } from '@angular/core/testing';

import { BasePage } from './base-page';

describe('BasePageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BasePage = TestBed.get(BasePage);
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { ChildBasePage } from './child-base-page';

describe('ChildBasePageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ChildBasePage = TestBed.get(ChildBasePage);
    expect(service).toBeTruthy();
  });
});

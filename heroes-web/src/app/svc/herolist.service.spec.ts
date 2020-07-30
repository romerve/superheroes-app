import { TestBed } from '@angular/core/testing';

import { HerolistService } from './herolist.service';

describe('HerolistService', () => {
  let service: HerolistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HerolistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

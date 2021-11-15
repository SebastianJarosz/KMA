import { TestBed } from '@angular/core/testing';

import { MenuPostionService } from './menu-postion.service';

describe('MenuPostionService', () => {
  let service: MenuPostionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MenuPostionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

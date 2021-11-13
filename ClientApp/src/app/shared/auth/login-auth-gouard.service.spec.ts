import { TestBed } from '@angular/core/testing';

import { LoginAuthGouardService } from './login-auth-gouard.service';

describe('LoginAuthGouardService', () => {
  let service: LoginAuthGouardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginAuthGouardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

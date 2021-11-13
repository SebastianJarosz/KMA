import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginAuthService } from './login-auth.service';

@Injectable({
  providedIn: 'root'
})
export class LoginAuthGouardService {

  constructor(public auth: LoginAuthService, public router: Router) { }
  canActivate(): boolean {
    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['/manager-view/main-panel']);
      return false;
    }
    return true;
  }
}

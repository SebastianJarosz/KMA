import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginAuthService {

  constructor() { }
  public isAuthenticated(): boolean {
    try{
      const token = localStorage.getItem('token');
      if(token != null){
        return false;
      }
    }catch{
      return true;
    }
    return true;
  }
}

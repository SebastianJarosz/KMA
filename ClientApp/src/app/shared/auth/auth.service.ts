import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor() { }
  
  public isAuthenticated(): boolean {
    try{
      let token = localStorage.getItem('token');
      if(token != null)
      {
        let user = sessionStorage.getItem('userData')
        if(user != null){
          return true;
        }
        localStorage.removeItem('token');
      }
    }catch{
      return false;
    }
    return false;
  }
}

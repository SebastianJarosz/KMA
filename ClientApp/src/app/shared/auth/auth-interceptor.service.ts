import { HttpHandler, HttpHeaders, HttpInterceptor, HttpParams, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler){
    try{
      let tokenParse = localStorage.getItem('token');
      let token = `${tokenParse}`.replace( /"/g ,' ');
      const modifiedReq = req.clone({
        headers: new HttpHeaders().set(
          'Authorization', `Bearer ${token}`
        )
      })
      return next.handle(modifiedReq);
    }
    catch{
      return next.handle(req);
    }
  }

}

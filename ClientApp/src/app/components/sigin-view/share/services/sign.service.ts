import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginPost } from '../models/login-post-model';
import { LoginResponse } from '../models/login-response-model';

@Injectable({
  providedIn: 'root'
})
export class SignService {

  constructor(private httpClient: HttpClient) { }

  post(url: string,  postData: LoginPost){
    return this.httpClient.post<LoginResponse>(url,
      postData,
      {
        observe:'response'
      }
      );
   }
}

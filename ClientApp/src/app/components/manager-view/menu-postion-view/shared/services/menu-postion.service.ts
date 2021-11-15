import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { MenuPostion } from '../models/menuPostion.model';


@Injectable({
  providedIn: 'root'
})
export class MenuPostionService {

  constructor(private httpClient: HttpClient) { }

  createMenuPostion(url: string,  postData: MenuPostion){
    return this.httpClient.post<MenuPostion>(url,
      postData,
      {
        observe:'response'
      });
  }

  getAllMenuPostions(url: string){
    return this.httpClient.get<MenuPostion>(url)
    .pipe(map((responseData: any) => {
      const responseArray: Array<MenuPostion> = [];
      for (const el of responseData){
          responseArray.push(el)
      }
      return responseArray;
    }));
  }

  updateMenuPostion(url: string,  postData: MenuPostion){
    return this.httpClient.put<MenuPostion>(url,
      postData,
      {
        observe:'response',
      });
   }

  deleteMenuPostion(url: string){
    return this.httpClient.delete<MenuPostion>(url,
      {
        observe:'response',
      });
   }
}

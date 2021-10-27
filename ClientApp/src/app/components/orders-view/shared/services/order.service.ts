import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IGlobalItem } from 'src/app/shared/interfaces/iglobal-item.models';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient) { }

  post(url: string,  postData: IGlobalItem){
   return this.httpClient.post<Order>(url,
     postData,
     {
       observe:'response'
     }
     );
  }

  get(url: string){;
    return this.httpClient.get<Order>(url)
    .pipe(map((responseData: any) => {
          return responseData;
    }));
  }

  getAll(url: string){
    return this.httpClient.get<Order>(url)
    .pipe(map((responseData: any) => {
      const responseArray: Array<Order> = [];
      for (const el of responseData){
          responseArray.push(el)
      }
      return responseArray;
    }));
  }
}

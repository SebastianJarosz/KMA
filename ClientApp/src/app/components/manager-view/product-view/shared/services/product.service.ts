import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  createProduct(url: string,  postData: Product){
    return this.httpClient.post<Product>(url,
      postData,
      {
        observe:'response'
      });
  }

  getAllProduct(url: string){
    return this.httpClient.get<Product>(url)
    .pipe(map((responseData: any) => {
      const responseArray: Array<Product> = [];
      for (const el of responseData){
          responseArray.push(el)
      }
      return responseArray;
    }));
  }

  updateProduct(url: string,  postData: Product){
    return this.httpClient.put<Product>(url,
      postData,
      {
        observe:'response',
      });
   }

  deleteProduct(url: string){
    return this.httpClient.delete<Product>(url,
      {
        observe:'response',
      });
   }
}

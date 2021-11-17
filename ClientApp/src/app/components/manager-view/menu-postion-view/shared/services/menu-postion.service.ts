import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Product } from '../../../product-view/shared/models/product.model';
import { MenuPostion } from '../models/menuPostion.model';
import { MenuPostionElement } from '../models/menuPostionElement.model';


@Injectable({
  providedIn: 'root'
})
export class MenuPostionService {

  productList = new Array<MenuPostionElement>();
  menuPostion: MenuPostion | any = null;
  
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

  getProductToCreateOrEditMenuPostion(url: string){
    return this.httpClient.get<Product>(url)
    .pipe(map((responseData: any) => {
      const responseArray: Array<Product> = [];
      for (const el of responseData){
          responseArray.push(el)
      }
      let i = 0;
      this.productList = new Array<MenuPostionElement>();
      responseArray.forEach(element => {
        i++;
        let product = new MenuPostionElement();
        product.position = i;
        product.productName = element.name;
        product.productCode = element.productCode;
        product.quantityOfProduct = 0;
        product.unit = element.sellUnit;
        this.productList.push(product);
      });
      if(this.menuPostion){
        for (let i = 0; i < this.menuPostion.products.length; i++) {
          for (let j = 0; j < this.productList.length; j++) {
            if (this.productList[j].productCode == this.menuPostion.products[i].productCode){
                this.productList[j].quantityOfProduct = this.menuPostion.products[i].quantityOfProduct;
            }
          }    
        }
      }
      this.menuPostion = null;
      return this.productList;
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

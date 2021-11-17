import { SelectionModel } from '@angular/cdk/collections';
import { Component, Input, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Product } from '../../product-view/shared/models/product.model';
import { ProductService } from '../../product-view/shared/services/product.service';
import { MenuPostion } from '../shared/models/menuPostion.model';
import { MenuPostionElement } from '../shared/models/menuPostionElement.model';
import { ProductRequest } from '../shared/models/postionRequest.model';
import { MenuPostionService } from '../shared/services/menu-postion.service';

@Component({
  selector: 'app-create-menu-postion',
  templateUrl: './create-menu-postion.component.html',
  styleUrls: ['./create-menu-postion.component.css']
})
export class CreateMenuPostionComponent implements OnInit{

  createMenuPostionForm: FormGroup = new FormGroup({});
  products = new FormArray([]);
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;



  constructor(private menuPostionService: MenuPostionService,
      private url: UrlSettings,
      public dialog: MatDialog,
      private router: Router) { }

  async ngOnInit() {
    this.createMenuPostionForm = new FormGroup({
      'name': new FormControl(null, Validators.required),
      'menuPostionCode': new FormControl(null, Validators.required),
      'unitPrice': new FormControl(null, Validators.required),
      'plu': new FormControl(null, Validators.required),
      'products':this.products,
    });
  }

  onNewMenuPostionSubmit(){
    let menuPostion = new MenuPostion();
    menuPostion.name = this.createMenuPostionForm.value.name.toString(),
    menuPostion.menuPostionCode = this.createMenuPostionForm.value.menuPostionCode.toString();
    menuPostion.unitPrice = this.createMenuPostionForm.value.unitPrice.toString();
    menuPostion.plu = this.createMenuPostionForm.value.plu.toString();
    let products = new Array<ProductRequest>(); 
    this.menuPostionService.productList.forEach(element => { 
      if(element.quantityOfProduct > 0.0){
          let product =  new ProductRequest();
          product.productName = element.productName;
          product.productCode = element.productCode;
          product.quantityOfProduct = element.quantityOfProduct
          products.push(product);
        }
      menuPostion.products = products;
    });
    this.createMenuPostion(menuPostion);
  }
  
  createMenuPostion (newMenuPostion: MenuPostion): void{
    this.menuPostionService.createMenuPostion(`${this.url.baseUrl}ProductsMenagment/v1/AddmenuPostion`, newMenuPostion)
    .subscribe(responseData  => {
      console.log(responseData);
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
      },
      error => {
          if(error.status == 403){
            this.error = 'Brak dostępu';
            console.error('Brak dostępu');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połaczeniaz serwerem');
          }
        }
      );  
  }
}

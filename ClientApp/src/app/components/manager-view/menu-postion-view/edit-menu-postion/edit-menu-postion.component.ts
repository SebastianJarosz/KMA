import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { MenuPostion } from '../shared/models/menuPostion.model';
import { ProductRequest } from '../shared/models/postionRequest.model';
import { MenuPostionService } from '../shared/services/menu-postion.service';

@Component({
  selector: 'app-edit-menu-postion',
  templateUrl: './edit-menu-postion.component.html',
  styleUrls: ['./edit-menu-postion.component.css']
})
export class EditMenuPostionComponent implements OnInit {

  editMenuPostionForm: FormGroup = new FormGroup({});
  products = new FormArray([]);
  error: string='NoErrors';

  constructor(@Inject(MAT_DIALOG_DATA) public data: MenuPostion,
              private url: UrlSettings,
              private menuPostionService: MenuPostionService,
              public dialog: MatDialog,
              private router: Router) { }

  ngOnInit(): void {
    this.editMenuPostionForm = new FormGroup({
      'name': new FormControl(this.data.name, Validators.required),
      'menuPostionCode': new FormControl(this.data.menuPostionCode, Validators.required),
      'unitPrice': new FormControl(this.data.unitPrice, Validators.required),
      'plu': new FormControl(this.data.plu, Validators.required),
      'products': this.products,
    });
    this.menuPostionService.menuPostion = this.data;
  }

  onEditMenuPostionSubmit(){
    let menuPostion = new MenuPostion();
    menuPostion.name = this.editMenuPostionForm.value.name.toString(),
    menuPostion.menuPostionCode = this.editMenuPostionForm.value.menuPostionCode.toString();
    menuPostion.unitPrice = this.editMenuPostionForm.value.unitPrice.toString();
    menuPostion.plu = this.editMenuPostionForm.value.plu.toString();
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
    this.editMenuPostion(menuPostion);
  }

  editMenuPostion(newMenuPostion: MenuPostion): void{
    this.menuPostionService.updateMenuPostion(`${this.url.baseUrl}ProductsMenagment/v1/EditMenuPostion/${newMenuPostion.menuPostionCode}`, newMenuPostion)
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

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { MeasureUnit } from '../shared/models/measureUnit.model';
import { MeasureUnitOption } from '../shared/models/measureUnitOption.interface';
import { Product } from '../shared/models/product.model';
import { ProductService } from '../shared/services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {


  createProductForm: FormGroup = new FormGroup({});
  productList?: Array<Product> | any;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;

  measureUnitOption: MeasureUnitOption[] = [
    {value: 'szt', viewValue: 'szt'},
    {value: 'kg', viewValue: 'kg'},
    {value: 'l', viewValue: 'l'},
    {value: 'opk', viewValue: 'opk'},
  ]

  constructor(private productService: ProductService,
     private url: UrlSettings,
     public dialog: MatDialog,
     private router: Router) { }

  ngOnInit(): void {
    this.createProductForm = new FormGroup({
      'name': new FormControl(null, Validators.required),
      'productCode': new FormControl(null, Validators.required),
      'measureUnit': new FormControl(null, Validators.required),
      'countable': new FormControl(null),
      'sellUnit': new FormControl(null, Validators.required),
      'isStockMenagment': new FormControl(null),
    });
  }

  async onSubmit(){
    let product = new Product();
    product.name = this.createProductForm.value.name.toString(),
    product.productCode = this.createProductForm.value.productCode.toString();
    product.measureUnit = this.createProductForm.value.measureUnit.toString();
    if(this.createProductForm.value.countable == null){
      product.countable = false;
    }
    else{
      product.countable = true;
    }
    product.sellUnit = this.createProductForm.value.sellUnit.toString();
    if(this.createProductForm.value.isStockMenagment == null){
      product.isStockMenagment = false;
    }
    else{
      product.isStockMenagment = true;
    }
    console.log(product);
    await this.createProduct(product);
    
  }
  createProduct (newProduct: Product): void{
    this.productService.createProduct(`${this.url.baseUrl}ProductsMenagment/v1/AddProduct`, newProduct)
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

import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { MeasureUnitOption } from '../shared/models/measureUnitOption.interface';
import { Product } from '../shared/models/product.model';
import { ProductService } from '../shared/services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  editProductForm: FormGroup = new FormGroup({});
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;

  measureUnitOption: MeasureUnitOption[] = [
    {value: 'szt', viewValue: 'szt'},
    {value: 'kg', viewValue: 'kg'},
    {value: 'l', viewValue: 'l'},
    {value: 'opk', viewValue: 'opk'},
  ]

  constructor(@Inject(MAT_DIALOG_DATA) public data: Product,
    private productService: ProductService,
    private url: UrlSettings,
    public dialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.editProductForm = new FormGroup({
      'name': new FormControl(this.data.name, Validators.required),
      'productCode': new FormControl(this.data.productCode, Validators.required),
      'measureUnit': new FormControl(this.data.measureUnit, Validators.required),
      'countable': new FormControl(this.data.countable),
      'sellUnit': new FormControl(this.data.sellUnit, Validators.required),
      'isStockMenagment': new FormControl(this.data.isStockMenagment),
    });
  }

  async onSubmit(){
    let product = new Product();
    product.name = this.editProductForm.value.name.toString(),
    product.productCode = this.editProductForm.value.productCode.toString();
    product.measureUnit = this.editProductForm.value.measureUnit.toString();
    if(this.editProductForm.value.countable == null || this.editProductForm.value.countable == false){
      product.countable = false;
    }
    else{
      product.countable = true;
    }
    product.sellUnit = this.editProductForm.value.sellUnit.toString();
    if(this.editProductForm.value.isStockMenagment == null || this.editProductForm.value.isStockMenagment == false){
      product.isStockMenagment = false;
    }
    else{
      product.isStockMenagment = true;
    }
    console.log(product);
    await this.editProduct(product);
    
  }
  editProduct (newProduct: Product): void{
    this.productService.updateProduct(`${this.url.baseUrl}ProductsMenagment/v1/EditProduct/${this.data.productCode}`, newProduct)
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

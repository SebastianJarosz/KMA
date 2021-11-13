import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Product } from '../shared/models/product.model';
import { ProductService } from '../shared/services/product.service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {

  isFetching: boolean = false;
  error: string='NoErrors';

  constructor(@Inject(MAT_DIALOG_DATA) public data: Product,
              private productService: ProductService,
              private url: UrlSettings,
              private router: Router) { }

  ngOnInit(): void {
  }
  deleteProduct(){
    this.productService.deleteProduct(`${this.url.baseUrl}ProductsMenagment/v1/DeleteProduct/${this.data.productCode}`)
    .subscribe(responseData => {
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
   },
    error => {
        if(error.status == 403){
          this.error = 'Błąd podczas przesłania polecenia do serwera';
          console.error(this.error);
        }else if(error.status == 500){
          this.error = 'Błąd połączenia z serwerem';
          console.error(this.error);
        }
        this.isFetching = false; 
      }
   );
  }
}

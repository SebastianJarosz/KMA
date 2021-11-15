import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CreateProductComponent } from '../create-product/create-product.component';

export interface User {
  name: string;
}

@Component({
  selector: 'app-product-navbar',
  templateUrl: './product-navbar.component.html',
  styleUrls: ['./product-navbar.component.css']
})
export class ProductNavbarComponent implements OnInit {

  constructor(public dialog: MatDialog,
              private router: Router){}
  ngOnInit() {

  }
  closeProductBrowser(){
    this.router.navigate([`/manager-view/main-panel`]);
  }
  openCreateProductDialog(){
    const dialogRef = this.dialog.open(CreateProductComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}

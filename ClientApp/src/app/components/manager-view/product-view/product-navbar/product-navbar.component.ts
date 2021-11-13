import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
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

  myControl = new FormControl();
  options: User[] = [{name: 'Mary'}, {name: 'Shelley'}, {name: 'Igor'}];
  filteredOptions?: Observable<User[]>;

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => (typeof value === 'string' ? value : value.name)),
      map(name => (name ? this._filter(name) : this.options.slice())),
    );
  }

  displayFn(user: User): string {
    return user && user.name ? user.name : '';
  }

  private _filter(name: string): User[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option => option.name.toLowerCase().includes(filterValue));
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

import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
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
import { MenuPostionElement } from '../shared/models/MenuPostionElement.model';
import { MenuPostionService } from '../shared/services/menu-postion.service';

@Component({
  selector: 'app-create-menu-postion',
  templateUrl: './create-menu-postion.component.html',
  styleUrls: ['./create-menu-postion.component.css']
})
export class CreateMenuPostionComponent implements OnInit {

  createMenuPostionForm: FormGroup = new FormGroup({});
  menuPostionList: Array<MenuPostion> | any;
  filteredOptions: Observable<Product[]> | any;
  productAutoCompliteBoxList?: Array<Product>;
  products = new FormArray([]);
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  productShortList: Array<MenuPostionElement> | any;
  dataSource: MatTableDataSource<MenuPostionElement> | any = new MatTableDataSource<MenuPostionElement>();
  selection = new SelectionModel<MenuPostionElement>(true, []);
  displayedColumns: string[] = ['select', 'position','name', 'productCode',  'quantityOfProduct'];

  constructor(private menuPostionService: MenuPostionService,
      private productService: ProductService,
      private url: UrlSettings,
      public dialog: MatDialog,
      private router: Router) { }

  ngOnInit(): void {
    this.createMenuPostionForm = new FormGroup({
      'name': new FormControl(null, Validators.required),
      'menuPostionCode': new FormControl(null, Validators.required),
      'unitPrice': new FormControl(null, Validators.required),
      'plu': new FormControl(null),
      'products':this.products,
    });
    this.productService.getAllProduct(`${this.url.baseUrl}ProductsMenagment/v1/Products`)
    .subscribe(responseData  => {
      let i = 0;
      this.productShortList = new Array<MenuPostionElement>();
      responseData.forEach(element => {
        i++;
        let product = new MenuPostionElement();
        product.position = i;
        product.name = element.name;
        product.productCode = element.productCode;
        product.quantityOfProduct = 0;
        this.productShortList.push(product);
      });
      this.dataSource = new MatTableDataSource(this.productShortList);
      },
      error => {
          if(error.status == 404){
            this.error = 'Błędny aders';
            console.error('Błędny aders');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połaczeniaz serwerem');
          }
        }
      );
  }
  getOptionText(option: Product) {
    if(option){
      return option.name;
    }
  }
  addProduct(option: Product) {
      console.log(option.name);
  }
  private _filter(name: string): Product[] {
    const filterValue = name.toString().toLowerCase();
    if(this.productAutoCompliteBoxList){
      return this.productAutoCompliteBoxList.filter(product => product.name.toLowerCase().includes(filterValue));
    }
    return new Array<Product>();
  }

  addShopPostion(): void{
    const control = new FormGroup({ 
      'productName': new FormControl(null, Validators.required),
      'productCode': new FormControl(null, Validators.required),
      'quantityOfProduct': new FormControl(null, Validators.required),
      });
      this.products.push(control);
  }
  removePostion(pos: number): void{
    this.products.removeAt(pos);
  }

  async onSubmit(){
    let menuPostion = new MenuPostion();
    menuPostion.name = this.createMenuPostionForm.value.name.toString(),
    menuPostion.menuPostionCode = this.createMenuPostionForm.value.menuPostionCode.toString();
    menuPostion.unitPrice = this.createMenuPostionForm.value.unitPrice.toString();
    menuPostion.products = this.products;
    console.log(menuPostion);
    await this.createMenuPostion(menuPostion);
    
  }
  createMenuPostion (newmenuPostion: MenuPostion): void{
    this.menuPostionService.createMenuPostion(`${this.url.baseUrl}menuPostionsMenagment/v1/AddmenuPostion`, newmenuPostion)
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
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: MenuPostionElement): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
  }
}

import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { MenuPostionElement } from '../../models/menuPostionElement.model';
import { MenuPostionService } from '../../services/menu-postion.service';

@Component({
  selector: 'app-products-postions',
  templateUrl: './products-postions.component.html',
  styleUrls: ['./products-postions.component.css']
})
export class ProductsPostionsComponent implements OnInit {

  dataSource: any = new MatTableDataSource<MenuPostionElement>();
  selection = new SelectionModel<MenuPostionElement>(true, []);
  displayedColumns: string[] = ['position','productName', 'productCode',  'quantityOfProduct', 'unit'];
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
   
  constructor(private menuPostionService: MenuPostionService,
            private url: UrlSettings) {
    
   }

  ngOnInit(): void {
      this.menuPostionService.getProductToCreateOrEditMenuPostion(`${this.url.baseUrl}ProductsMenagment/v1/Products`)
        .subscribe(responseData  => {
          console.log(responseData);
          this.dataSource = new MatTableDataSource(responseData)
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

  removePostion(element: MenuPostionElement){
    if(this.menuPostionService.productList[element.position-1].quantityOfProduct > 0){
      if(this.menuPostionService.productList[element.position-1].unit == 'szt'){
        this.menuPostionService.productList[element.position-1].quantityOfProduct -= 1;
      }
      else{
        this.menuPostionService.productList[element.position-1].quantityOfProduct -= 0.01;
      }
    }
  }

  addPostion(element: MenuPostionElement){
    if(this.menuPostionService.productList[element.position-1].quantityOfProduct < 999){
      if(this.menuPostionService.productList[element.position-1].unit == 'szt'){
        this.menuPostionService.productList[element.position-1].quantityOfProduct += 1;
      }
      else{
        this.menuPostionService.productList[element.position-1].quantityOfProduct += 0.01;
      }
    }
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

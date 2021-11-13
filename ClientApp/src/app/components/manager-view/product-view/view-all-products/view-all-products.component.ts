import { LiveAnnouncer } from '@angular/cdk/a11y';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Product } from '../shared/models/product.model';
import { ProductService } from '../shared/services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteProductComponent } from '../delete-product/delete-product.component';
import { EditProductComponent } from '../edit-product/edit-product.component';

@Component({
  selector: 'app-view-all-products',
  templateUrl: './view-all-products.component.html',
  styleUrls: ['./view-all-products.component.css']
})
export class ViewAllProductsComponent implements OnInit, AfterViewInit {

  productList?: Array<Product> | any;
  dataSource: MatTableDataSource<Product> | any = new MatTableDataSource<Product>() ;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  displayedColumns: string[] = ['name', 'productCode', 'measureUnit', 'sellUnit', 'countable', 'isStockMenagment', 'Edit', 'Delete'];
  
  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(private productService: ProductService,
    private url: UrlSettings,
    public dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer) {}

  
  ngOnInit(): void {
    this.productService.getAllProduct(`${this.url.baseUrl}ProductsMenagment/v1/Products`)
    .subscribe(responseData  => {
      this.productList = responseData;
      this.dataSource = new MatTableDataSource(this.productList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(this.productList);
      this.isNotEmpty = (this.productList.length > 0) ? true : false;
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
  ngAfterViewInit(): void {
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDeleteProductDialog(product: Product) {
    this.dialog.open(DeleteProductComponent, {
      data: {
        name: product.name,
        productCode: product.productCode,
      },
    });
  }
  openEditProductDialog(product: Product) {
    this.dialog.open(EditProductComponent, {
      data: {
        name: product.name,
        productCode: product.productCode,
        countable: product.countable,
        measureUnit: product.measureUnit,
        sellUnit: product.sellUnit,
        isStockMenagment: product.isStockMenagment
      },
    });
  }
}

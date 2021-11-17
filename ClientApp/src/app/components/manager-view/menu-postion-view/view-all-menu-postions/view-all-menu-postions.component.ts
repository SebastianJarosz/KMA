import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { DeleteMenuPostionComponent } from '../delete-menu-postion/delete-menu-postion.component';
import { EditMenuPostionComponent } from '../edit-menu-postion/edit-menu-postion.component';
import { MenuPostion } from '../shared/models/menuPostion.model';
import { MenuPostionService } from '../shared/services/menu-postion.service';

@Component({
  selector: 'app-view-all-menu-postions',
  templateUrl: './view-all-menu-postions.component.html',
  styleUrls: ['./view-all-menu-postions.component.css']
})
export class ViewAllMenuPostionsComponent implements OnInit {

  menuPostionsList?: Array<MenuPostion> | any;
  dataSource: MatTableDataSource<MenuPostion> | any = new MatTableDataSource<MenuPostion>() ;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  displayedColumns: string[] = ['name', 'menuPostionCode', 'unitPrice', 'plu', 'Edit', 'Delete'];
  
  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(private menuPostionService: MenuPostionService,
    private url: UrlSettings,
    public dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer) {}

  
  ngOnInit(): void {
    this.menuPostionService.getAllMenuPostions(`${this.url.baseUrl}ProductsMenagment/v1/MenuPostions`)
    .subscribe(responseData  => {
      this.menuPostionsList = responseData;
      this.dataSource = new MatTableDataSource(this.menuPostionsList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(this.menuPostionsList);
      this.isNotEmpty = (this.menuPostionsList.length > 0) ? true : false;
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
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDeleteMenuPostionDialog(menuPostion: MenuPostion) {
    this.dialog.open(DeleteMenuPostionComponent, {
      data: {
        name: menuPostion.name,
        menuPostionCode: menuPostion.menuPostionCode,
      },
    });
  }
  openEditProductDialog(menuPostion: MenuPostion) {
    this.dialog.open(EditMenuPostionComponent, {
      data: {
        name: menuPostion.name,
        menuPostionCode: menuPostion.menuPostionCode,
        unitPrice: menuPostion.unitPrice,
        plu: menuPostion.plu,
        products: menuPostion.products,
      },
    });
  }

}

import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { MenuPostion } from '../shared/models/menuPostion.model';
import { MenuPostionService } from '../shared/services/menu-postion.service';

@Component({
  selector: 'app-delete-menu-postion',
  templateUrl: './delete-menu-postion.component.html',
  styleUrls: ['./delete-menu-postion.component.css']
})
export class DeleteMenuPostionComponent implements OnInit {

  isFetching: boolean = false;
  error: string='NoErrors';

  constructor(@Inject(MAT_DIALOG_DATA) public data: MenuPostion,
              private menuPostionService: MenuPostionService,
              private url: UrlSettings,
              private router: Router) { }

  ngOnInit(): void {
  }
  deleteMenuPostion(){
    this.menuPostionService.deleteMenuPostion(`${this.url.baseUrl}ProductsMenagment/v1/DeleteMenuPostion/${this.data.menuPostionCode}`)
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

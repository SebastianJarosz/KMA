import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CreateMenuPostionComponent } from '../create-menu-postion/create-menu-postion.component';

@Component({
  selector: 'app-menu-postion-navbar',
  templateUrl: './menu-postion-navbar.component.html',
  styleUrls: ['./menu-postion-navbar.component.css']
})
export class MenuPostionNavbarComponent implements OnInit {

  constructor(public dialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
  }
  closeMenuPostionBrowser(){
    this.router.navigate([`/manager-view/main-panel`]);
  }
  openCreateMenuPostionDialog(){
    const dialogRef = this.dialog.open(CreateMenuPostionComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}

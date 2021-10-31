import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css']
})
export class TopNavbarComponent implements OnInit {
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  goToOrderView(url: string){
    this.router.navigate([`/orders-view/${url}`]);
  }
}

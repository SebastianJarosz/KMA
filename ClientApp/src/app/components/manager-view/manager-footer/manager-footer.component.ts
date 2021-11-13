import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manager-footer',
  templateUrl: './manager-footer.component.html',
  styleUrls: ['./manager-footer.component.css']
})
export class ManagerFooterComponent implements OnInit {

  name?: string;
  surname?: string;
  role?: string;

  constructor() { }

  ngOnInit(): void {
    let user = sessionStorage.getItem('userData');
    let objectUser = JSON.parse(user ? user : "")
    this.name = objectUser.name;
    this.surname = objectUser.surname;
    this.role = objectUser.roleName
  }

}

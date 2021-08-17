import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.sass']
})
export class SignInComponent implements OnInit {

  signInForm?: FormGroup | any;
  hide?: boolean | any;
  isFetching?: boolean | any;
  error?: string | any;

  constructor() { }

  public ngOnInit(): void {
    this.signInForm = new FormGroup({
      'userName': new FormControl(null, Validators.required),
      'password': new FormControl(null, Validators.required),
    }); 
    this.hide = true;
    this.isFetching = false;
    this.error = 'NoErrors';
  }

  public signInUser(){

  }

}

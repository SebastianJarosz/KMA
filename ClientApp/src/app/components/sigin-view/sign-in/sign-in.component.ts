import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { LoginPost } from '../share/models/login-post-model';
import { User } from '../share/models/user.model';
import { SignService } from '../share/services/sign.service';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  signInForm: FormGroup = new FormGroup({});
  hide: boolean = true;
  isFetching: boolean = false;
  error: string='NoErrors';


  constructor(private signService: SignService, private router: Router, 
              private url: UrlSettings) { }

  ngOnInit(): void {
    this.signInForm = new FormGroup({
      'userName': new FormControl(null, Validators.required),
      'password': new FormControl(null, Validators.required),
    }); 
    this.error = 'NoErrors';
  }

  onSubmit(){
    this.isFetching = true;
    let login = new LoginPost();
    login.userName = this.signInForm.value.userName.toString();
    login.password = this.signInForm.value.password.toString();
    this.signService.post(`${this.url.baseUrl}Users/v1/UserLogin`, login).subscribe(responseData => {
      responseData.body?.token;
      localStorage.setItem("token", JSON.stringify(responseData.body?.token));
      let user: User | any = responseData.body;
      user.token = "";
      sessionStorage.setItem("userData", JSON.stringify(user));
      this.router.navigate([`/manager-view/main-panel`]);
      this.isFetching = false; 
     },
      error => {
          if(error.status == 403){
            this.error = 'Nieprawidłowy login lub hasło';
            console.error('Nieprawidłowy login lub hasło');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połączenia z serwerem');
          }
          this.isFetching = false; 
        }
     );
  }
}

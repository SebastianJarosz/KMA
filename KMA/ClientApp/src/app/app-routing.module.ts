import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginViewComponent } from './components/login-view/login-view.component';
import { SignInComponent } from './components/login-view/sign-in/sign-in.component';
import { SignUpComponent } from './components/login-view/sign-up/sign-up.component';

const routes: Routes = [
  {path: '', component: AppComponent, children:[
    {path: 'kds-app', component: LoginViewComponent, children:[
    {path: 'sign-in', component: SignInComponent},
    {path: 'sign-up', component: SignUpComponent},
    ]},
  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

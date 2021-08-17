import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginViewComponent } from './components/login-view/login-view.component';
import { SignInComponent } from './components/login-view/sign-in/sign-in.component';
import { SignUpComponent } from './components/login-view/sign-up/sign-up.component';
import { MainPanelComponent } from './components/main-panel/main-panel.component';
import { NavbarComponent } from './components/main-panel/navbar/navbar.component';
import { OrdersManagmentComponent } from './components/main-panel/orders-managment/orders-managment.component';
import { OrderComponent } from './components/main-panel/orders-managment/order/order.component';
import { OrderItemComponent } from './components/main-panel/orders-managment/order/order-item/order-item.component';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { InProgressSectionComponent } from './components/customer-view/in-progress-section/in-progress-section.component';
import { ReadySectionComponent } from './components/customer-view/ready-section/ready-section.component';
import { InProgressTicketComponent } from './components/customer-view/in-progress-section/in-progress-ticket/in-progress-ticket.component';
import { ReadyTicketComponent } from './components/customer-view/in-progress-section/ready-ticket/ready-ticket.component';
import { ManagerPanelComponent } from './components/manager-panel/manager-panel.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { MatSliderModule } from '@angular/material/slider';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  declarations: [
    AppComponent,
    LoginViewComponent,
    SignInComponent,
    SignUpComponent,
    MainPanelComponent,
    NavbarComponent,
    OrdersManagmentComponent,
    OrderComponent,
    OrderItemComponent,
    CustomerViewComponent,
    InProgressSectionComponent,
    ReadySectionComponent,
    InProgressTicketComponent,
    ReadyTicketComponent,
    ManagerPanelComponent,
    AdminPanelComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSliderModule,
    MatCardModule,
    MatButtonModule,
    MatTabsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatCheckboxModule,
    MatProgressBarModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatMenuModule,
    MatSidenavModule,
    MatTooltipModule,
    MatDialogModule,
    MatTableModule,
    MatGridListModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

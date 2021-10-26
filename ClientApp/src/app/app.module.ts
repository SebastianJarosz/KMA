import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
import { MatDividerModule } from '@angular/material/divider';
import { MatRadioModule } from '@angular/material/radio';


import { OrdersViewComponent } from './components/orders-view/orders-view.component';
import { ActiveOrdersComponent } from './components/orders-view/active-orders/active-orders.component';
import { OldOrdersComponent } from './components/orders-view/old-orders/old-orders.component';
import { OrderService } from './components/orders-view/shared/services/order.service';
import { UrlSettings } from './shared/models/url-settings.model';
import { TopNavbarComponent } from './components/orders-view/top-navbar/top-navbar.component';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { InprogressComponent } from './components/customer-view/inprogress/inprogress.component';
import { ReadyComponent } from './components/customer-view/ready/ready.component';
import { OrderTicketComponent } from './components/orders-view/shared/components/order-ticket/order-ticket.component';
import { OrderTicketPostionComponent } from './components/orders-view/shared/components/order-ticket-postion/order-ticket-postion.component';


@NgModule({
  declarations: [
    AppComponent,
    OrdersViewComponent,
    ActiveOrdersComponent,
    OldOrdersComponent,
    TopNavbarComponent,
    CustomerViewComponent,
    InprogressComponent,
    ReadyComponent,
    OrderTicketComponent,
    OrderTicketPostionComponent
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
    MatDividerModule,
    MatRadioModule,
  ],
  providers: [
    UrlSettings,
    OrderService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
1
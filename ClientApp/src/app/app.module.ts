import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSelectModule } from '@angular/material/select'; 

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
import { Color } from './shared/models/color.model';
import { MessageText } from './shared/models/messageText.model';
import { ManagerViewComponent } from './components/manager-view/manager-view.component';
import { ManagerTopNavBarComponent } from './components/manager-view/manager-top-nav-bar/manager-top-nav-bar.component';
import { MainPanelComponent } from './components/manager-view/main-panel/main-panel.component';
import { ProductViewComponent } from './components/manager-view/product-view/product-view.component';
import { CreateProductComponent } from './components/manager-view/product-view/create-product/create-product.component';
import { EditProductComponent } from './components/manager-view/product-view/edit-product/edit-product.component';
import { DeleteProductComponent } from './components/manager-view/product-view/delete-product/delete-product.component';
import { ViewProductComponent } from './components/manager-view/product-view/view-product/view-product.component';
import { MenuPostionViewComponent } from './components/manager-view/menu-postion-view/menu-postion-view.component';
import { CreateMenuPostionComponent } from './components/manager-view/menu-postion-view/create-menu-postion/create-menu-postion.component';
import { EditMenuPostionComponent } from './components/manager-view/menu-postion-view/edit-menu-postion/edit-menu-postion.component';
import { DeleteMenuPostionComponent } from './components/manager-view/menu-postion-view/delete-menu-postion/delete-menu-postion.component';
import { ViewMenuPostionComponent } from './components/manager-view/menu-postion-view/view-menu-postion/view-menu-postion.component';
import { SiginViewComponent } from './components/sigin-view/sigin-view.component';
import { ManagerFooterComponent } from './components/manager-view/manager-footer/manager-footer.component';
import { SignInComponent } from './components/sigin-view/sign-in/sign-in.component';
import { SignService } from './components/sigin-view/share/services/sign.service';
import { User } from './components/sigin-view/share/models/user.model';
import { ViewAllProductsComponent } from './components/manager-view/product-view/view-all-products/view-all-products.component';
import { ViewAllMenuPostionsComponent } from './components/manager-view/menu-postion-view/view-all-menu-postions/view-all-menu-postions.component';
import { ProductNavbarComponent } from './components/manager-view/product-view/product-navbar/product-navbar.component';
import { ProductService } from './components/manager-view/product-view/shared/services/product.service';
import { Router } from '@angular/router';
import { MatSortModule } from '@angular/material/sort';
import { AuthGuardService } from './shared/auth/auth-guard.service';
import { AuthService } from './shared/auth/auth.service';
import { AuthInterceptorService } from './shared/auth/auth-interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    OrdersViewComponent,
    CreateProductComponent,
    ActiveOrdersComponent,
    OldOrdersComponent,
    TopNavbarComponent,
    CustomerViewComponent,
    InprogressComponent,
    ReadyComponent,
    OrderTicketComponent,
    OrderTicketPostionComponent,
    ManagerViewComponent,
    ManagerTopNavBarComponent,
    MainPanelComponent,
    ProductViewComponent,
    EditProductComponent,
    DeleteProductComponent,
    ViewProductComponent,
    MenuPostionViewComponent,
    CreateMenuPostionComponent,
    EditMenuPostionComponent,
    DeleteMenuPostionComponent,
    ViewMenuPostionComponent,
    SiginViewComponent,
    ManagerFooterComponent,
    SignInComponent,
    ViewAllProductsComponent,
    ViewAllMenuPostionsComponent,
    ProductNavbarComponent,
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
    MatPaginatorModule,
    MatAutocompleteModule,
    MatSelectModule,
    MatSortModule,
  ],
  providers: [
    AuthGuardService, 
    AuthService, 
    UrlSettings,
    OrderService,
    Color,
    MessageText,
    SignService,
    User,
    ProductService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
1
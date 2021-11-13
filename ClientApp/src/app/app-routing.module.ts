import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { MainPanelComponent } from './components/manager-view/main-panel/main-panel.component';
import { ManagerViewComponent } from './components/manager-view/manager-view.component';
import { MenuPostionViewComponent } from './components/manager-view/menu-postion-view/menu-postion-view.component';
import { ViewAllMenuPostionsComponent } from './components/manager-view/menu-postion-view/view-all-menu-postions/view-all-menu-postions.component';
import { ProductViewComponent } from './components/manager-view/product-view/product-view.component';
import { ViewAllProductsComponent } from './components/manager-view/product-view/view-all-products/view-all-products.component';
import { ActiveOrdersComponent } from './components/orders-view/active-orders/active-orders.component';
import { OldOrdersComponent } from './components/orders-view/old-orders/old-orders.component';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';
import { SiginViewComponent } from './components/sigin-view/sigin-view.component';
import { AuthGuardService } from './shared/auth/auth-guard.service';
import { LoginAuthGouardService } from './shared/auth/login-auth-gouard.service';

const routes: Routes = [
  {path: 'orders-view', component: OrdersViewComponent, children: [
    {path: 'active-orders', component: ActiveOrdersComponent},
    {path: 'old-orders', component: OldOrdersComponent},  
  ]},
  {path: 'customer-view', component: CustomerViewComponent},
  {path: 'sign-in-view', canActivate: [LoginAuthGouardService], component: SiginViewComponent },
  {path: 'manager-view',  canActivate: [AuthGuardService], component: ManagerViewComponent, children: [
    {path: 'main-panel', component: MainPanelComponent},
    {path: 'product-view', component: ProductViewComponent, children: [
      {path: 'view-all-products', component: ViewAllProductsComponent},
    ]},  
    {path: 'menu-postion-view', component: MenuPostionViewComponent, children: [
      {path: 'view-all-menu-postions', component: ViewAllMenuPostionsComponent},
    ]},  
  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

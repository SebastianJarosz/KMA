import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { ActiveOrdersComponent } from './components/orders-view/active-orders/active-orders.component';
import { OldOrdersComponent } from './components/orders-view/old-orders/old-orders.component';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';

const routes: Routes = [
  {path: 'orders-view', component: OrdersViewComponent, children: [
    {path: 'active-orders', component: ActiveOrdersComponent},
    {path: 'old-orders', component: OldOrdersComponent},  
  ]},
  {path: 'customer-view', component: CustomerViewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

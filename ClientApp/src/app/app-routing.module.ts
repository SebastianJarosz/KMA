import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';

const routes: Routes = [
  {path: 'orders-view', component: OrdersViewComponent},
  {path: 'customer-view', component: CustomerViewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';

const routes: Routes = [
  {path: 'orders-view', component: OrdersViewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Order } from '../orders-view/shared/models/order.model';
import { OrderService } from '../orders-view/shared/services/order.service';


@Component({
  selector: 'app-customer-view',
  templateUrl: './customer-view.component.html',
  styleUrls: ['./customer-view.component.css']
})
export class CustomerViewComponent implements OnInit {

  inProgressOrderList?: Array<Order> | any;
  readyOrderList?: Array<Order> | any;
  order?: Order;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  inProgressOrdersSubscription?: Subscription;
  readyOrdersSubscription?: Subscription;

  constructor(private orderService: OrderService, private url: UrlSettings) { }

  ngOnInit(): void {
    const source = interval(2000);
    this.inProgressOrdersSubscription = source.subscribe(val => this.GetInProgressOrders());
    this.readyOrdersSubscription = source.subscribe(val => this.GetReadyOrders());
  }

  GetInProgressOrders(){
    this.orderService.getAll(`${this.url.baseUrl}OrdersMenagment/v1/OrdersInProgress`)
    .subscribe(responseData  => {
      this.inProgressOrderList = responseData;
      this.isNotEmpty = (this.inProgressOrderList.length > 0) ? true : false;
      },
      error => {
          if(error.status == 404){
            this.error = 'Odmowa dostępu';
            console.error('Odmowa dostępu');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połaczeniaz serwerem');
          }
        }
      );
  }
  GetReadyOrders(){
    this.orderService.getAll(`${this.url.baseUrl}OrdersMenagment/v1/ReadyOrders`)
    .subscribe(responseData  => {
      this.readyOrderList = responseData;
      this.isNotEmpty = (this.readyOrderList.length > 0) ? true : false;
      },
      error => {
          if(error.status == 404){
            this.error = 'Odmowa dostępu';
            console.error('Odmowa dostępu');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połaczeniaz serwerem');
          }
        }
      );
  }
}

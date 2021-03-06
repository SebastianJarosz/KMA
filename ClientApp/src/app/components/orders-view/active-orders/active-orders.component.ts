import { Component, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Order } from '../shared/models/order.model';
import { OrderService } from '../shared/services/order.service';

@Component({
  selector: 'app-active-orders',
  templateUrl: './active-orders.component.html',
  styleUrls: ['./active-orders.component.css']
})
export class ActiveOrdersComponent implements OnInit {

  orderList?: Array<Order> | any;
  order?: Order;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  subscription?: Subscription;

  constructor(private orderService: OrderService, private url: UrlSettings) { }

  ngOnInit(): void {
    const source = interval(2000);
    this.subscription = source.subscribe(val => this.GetActiveOrders());
  }

GetActiveOrders(){
  this.orderService.getAll(`${this.url.baseUrl}OrdersMenagment/v1/Orders`)
  .subscribe(responseData  => {
    this.orderList = responseData;
    this.isNotEmpty = (this.orderList.length > 0) ? true : false;
    },
    error => {
        if(error.status == 404){
          this.error = 'Błędny aders';
          console.error('Błędny aders');
        }else if(error.status == 500){
          this.error = 'Błąd połączenia z serwerem';
          console.error('Błąd połaczeniaz serwerem');
        }
      }
    );
  }

}

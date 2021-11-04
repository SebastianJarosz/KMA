import { Component, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Order } from '../shared/models/order.model';
import { OrderService } from '../shared/services/order.service';


@Component({
  selector: 'app-old-orders',
  templateUrl: './old-orders.component.html',
  styleUrls: ['./old-orders.component.css']
})
export class OldOrdersComponent implements OnInit {

  orderList?: Array<Order> | any;
  order?: Order;
  isFetching: boolean = false;
  error: string='NoErrors';
  isNotEmpty?: boolean;
  subscription?: Subscription;

  constructor(private orderService: OrderService, private url: UrlSettings) { }

  ngOnInit(): void {
    this.GetActiveOrders();
  }

GetActiveOrders(){
  this.orderService.getAll(`${this.url.baseUrl}OrdersMenagment/v1/ClosedOrders`)
  .subscribe(responseData  => {
    this.orderList = responseData;
    this.isNotEmpty = (this.orderList.length > 0) ? true : false;
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
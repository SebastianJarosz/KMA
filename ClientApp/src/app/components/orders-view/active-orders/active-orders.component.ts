import { Component, OnInit } from '@angular/core';
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

  constructor(private orderService: OrderService, private url: UrlSettings) { }

  ngOnInit(): void {
    this.orderService.getAll(`${this.url.baseUrl}OrdersMenagment/v1/Orders`)
    .subscribe(responseData  => {
      this.orderList = responseData;
      console.log(this.orderList);
      this.isNotEmpty = (this.orderList.length > 0) ? true : false;
      },
      error => {
          if(error.status == 403){
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

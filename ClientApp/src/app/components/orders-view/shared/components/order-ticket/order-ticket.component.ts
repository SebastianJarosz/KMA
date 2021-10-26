import { Component, Input, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order, OrderPostion } from '../../models/order.model';

@Component({
  selector: 'app-order-ticket',
  templateUrl: './order-ticket.component.html',
  styleUrls: ['./order-ticket.component.css']
})
export class OrderTicketComponent implements OnInit {

  orderGuid?: string;
  orderNumber?: number;
  creationTime?: Date;
  modificationTime?: Date;
  status?: string;
  orderPostionList?: Array<OrderPostion>;
  constructor() { }

  @Input() order?: Order;
  ngOnInit(): void {
    
    this.orderNumber = this.order?.orderNumber;
    this.status = this.order?.status;
    this.orderPostionList = this.order?.orderPostion;
  }

}

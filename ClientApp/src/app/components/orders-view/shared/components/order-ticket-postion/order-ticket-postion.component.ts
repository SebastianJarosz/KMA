import { Component, Input, OnInit } from '@angular/core';
import { OrderPostion } from '../../models/order.model';

@Component({
  selector: 'app-order-ticket-postion',
  templateUrl: './order-ticket-postion.component.html',
  styleUrls: ['./order-ticket-postion.component.css']
})
export class OrderTicketPostionComponent implements OnInit {

  menuPostionName?: string;
  menuPostionCode?: string;
  quantityOfMenuPostion?: number;
  isReady?: boolean;

  constructor() { }
  @Input() orderPostion?: OrderPostion;
  ngOnInit(): void {
    this.menuPostionName = this.orderPostion?.menuPostionName;
    this.menuPostionCode = this.orderPostion?.menuPostionCode;
    this.quantityOfMenuPostion = this.orderPostion?.quantityOfMenuPostion;
    this.isReady = this.orderPostion?.isReady;
  }

}
